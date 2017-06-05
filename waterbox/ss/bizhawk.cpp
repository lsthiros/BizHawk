#include "ss.h"
#include "stream/MemoryStream.h"
#include <memory>
#include "cdrom/cdromif.h"
#include "cdb.h"
#include "smpc.h"
#include "cart.h"

#define EXPORT extern "C" ECL_EXPORT
using namespace MDFN_IEN_SS;

static int32 (*FirmwareSizeCallback)(const char* filename);
static void (*FirmwareDataCallback)(const char* filename, uint8* dest);

std::unique_ptr<MemoryStream> GetFirmware(const char* filename)
{
	int32 length = FirmwareSizeCallback(filename);
	auto buffer = new uint8[length];
	FirmwareDataCallback(filename, buffer);
	auto ms = std::unique_ptr<MemoryStream>(new MemoryStream(length, true));
	ms->write(buffer, length);
	ms->seek(0, SEEK_SET);
	delete[] buffer;
	return ms;
}

EXPORT void SetFirmwareCallbacks(int32 (*sizecallback)(const char *filename), void (*datacallback)(const char* filename, uint8* dest))
{
	FirmwareSizeCallback = sizecallback;
	FirmwareDataCallback = datacallback;
}

struct FrontendTOC
{
	int32 FirstTrack;
	int32 LastTrack;
	int32 DiskType;
	struct
	{
		int32 Address;
		int32 Control;
		int32 Lba;
		int32 Valid;
	} Tracks[101];
};

static void (*ReadTOCCallback)(int disk, FrontendTOC *dest);
static void (*ReadSector2448Callback)(int disk, int lba, uint8 *dest);

EXPORT void SetCDCallbacks(void (*toccallback)(int disk, FrontendTOC *dest), void (*sectorcallback)(int disk, int lba, uint8 *dest))
{
	ReadTOCCallback = toccallback;
	ReadSector2448Callback = sectorcallback;
}

class MyCDIF : public CDIF
{
	private:
	int disk;

  public:
	MyCDIF(int disk) : disk(disk)
	{
		FrontendTOC t;
		ReadTOCCallback(disk, &t);
		disc_toc.first_track = t.FirstTrack;
		disc_toc.last_track = t.LastTrack;
		disc_toc.disc_type = t.DiskType;
		for (int i = 0; i < 101; i++)
		{
			disc_toc.tracks[i].adr = t.Tracks[i].Address;
			disc_toc.tracks[i].control = t.Tracks[i].Control;
			disc_toc.tracks[i].lba = t.Tracks[i].Lba;
			disc_toc.tracks[i].valid = t.Tracks[i].Valid;			
		}
	}

	virtual void HintReadSector(int32 lba) {}
	virtual bool ReadRawSector(uint8 *buf, int32 lba)
	{
		ReadSector2448Callback(disk, lba, buf);
		return true;
	}
	virtual bool ReadRawSectorPWOnly(uint8 *pwbuf, int32 lba, bool hint_fullread)
	{
		uint8 buff[2448];
		ReadSector2448Callback(disk, lba, buff);
		memcpy(pwbuf, buff + 2352, 96);
		return true;
	}
};

static std::vector<CDIF *> CDInterfaces;
static uint32* FrameBuffer;
static uint8 IsResetPushed; // 1 or 0

namespace MDFN_IEN_SS
{
extern bool LoadCD(std::vector<CDIF *> *CDInterfaces);
}
EXPORT bool Init(int numDisks)
{
	FrameBuffer = (uint32*)alloc_invisible(1024 * 1024);
	for (int i = 0; i < numDisks; i++)
		CDInterfaces.push_back(new MyCDIF(i));
	auto ret = LoadCD(&CDInterfaces);
	if (ret)
		SMPC_SetInput(12, nullptr, &IsResetPushed);
	return ret;
}

EXPORT void HardReset()
{
	// soft reset is handled as a normal button
	SS_Reset(true);
}

EXPORT void SetDisk(int disk, bool open)
{
	CDB_SetDisc(open, disk < 0 ? nullptr : CDInterfaces[disk]);
}

int setting_ss_slstartp = 0;
int setting_ss_slendp = 255;
int setting_ss_slstart = 0;
int setting_ss_slend = 239;
int setting_ss_region_default = SMPC_AREA_JP;
int setting_ss_cart = CART_NONE;
bool setting_ss_correct_aspect = true;
bool setting_ss_h_blend = false;
bool setting_ss_h_overscan = true;
bool setting_ss_region_autodetect = true;
bool setting_ss_input_sport1_multitap = false;
bool setting_ss_input_sport0_multitap = false;

namespace MDFN_IEN_SS
{
extern void Emulate(EmulateSpecStruct *espec_arg);
}

struct FrameAdvanceInfo
{
	int16* SoundBuf;

	uint32* Pixels;

	int64 MasterCycles;

	int32 SoundBufMaxSize;
	int32 SoundBufSize;

	int32 Width;
	int32 Height;

	// Set by the system emulation code every frame, to denote the horizontal and vertical offsets of the image, and the size
	// of the image.  If the emulated system sets the elements of LineWidths, then the width(w) of this structure
	// is ignored while drawing the image.
	// int32 x, y, h;

	// Set(optionally) by emulation code.  If InterlaceOn is true, then assume field height is 1/2 DisplayRect.h, and
	// only every other line in surface (with the start line defined by InterlacedField) has valid data
	// (it's up to internal Mednafen code to deinterlace it).
	// bool InterlaceOn;
	// bool InterlaceField;
};

EXPORT void FrameAdvance(FrameAdvanceInfo& f)
{
	EmulateSpecStruct e;
	int32 LineWidths[1024];
	e.pixels = FrameBuffer;
	e.pitch32 = 1024;
	e.LineWidths = LineWidths;
	e.SoundBuf = f.SoundBuf;
	e.SoundBufMaxSize = f.SoundBufMaxSize;
	Emulate(&e);
	f.SoundBufSize = e.SoundBufSize;
	f.MasterCycles = e.MasterCycles;

	int w = 256;
	for (int i = 0; i < e.h; i++)
		w = std::max(w, LineWidths[i]);

	const uint32* src = FrameBuffer;
	uint32* dst = f.Pixels;
	const int srcp = 1024;
	const int dstp = w;
	src += e.y * srcp + e.x;

	for (int j = 0; j < e.h; j++, src += srcp, dst += dstp)
	{
		memcpy(dst, src, LineWidths[j + e.y] * sizeof(*dst));
	}
	f.Width = w;
	f.Height = e.h;
}

/*void VDP2REND_SetGetVideoParams(MDFNGI* gi, const bool caspect, const int sls, const int sle, const bool show_h_overscan, const bool dohblend)
{
 CorrectAspect = caspect;
 ShowHOverscan = show_h_overscan;
 DoHBlend = dohblend;
 LineVisFirst = sls;
 LineVisLast = sle;
 //
 //
 //
 gi->fb_width = 704;

 if(PAL)
 {
  gi->nominal_width = (ShowHOverscan ? 365 : 354);
  gi->fb_height = 576;
 }
 else
 {
  gi->nominal_width = (ShowHOverscan ? 302 : 292);
  gi->fb_height = 480;
 }
 gi->nominal_height = LineVisLast + 1 - LineVisFirst;


 gi->lcm_width = (ShowHOverscan? 10560 : 10240);
 gi->lcm_height = (LineVisLast + 1 - LineVisFirst) * 2;
 //
 //
 //
 if(!CorrectAspect)
 {
  gi->nominal_width = (ShowHOverscan ? 352 : 341);
  gi->lcm_width = gi->nominal_width * 2;
 }
}
void SetGetVideoParams(MDFNGI* gi, const bool caspect, const int sls, const int sle, const bool show_h_overscan, const bool dohblend)
{
 if(PAL)
  gi->fps = 65536 * 256 * (1734687500.0 / 61 / 4 / 455 / ((313 + 312.5) / 2.0));
 else
  gi->fps = 65536 * 256 * (1746818181.8 / 61 / 4 / 455 / ((263 + 262.5) / 2.0));

 VDP2REND_SetGetVideoParams(gi, caspect, sls, sle, show_h_overscan, dohblend);
}*/


// if (BackupRAM_Dirty)SaveBackupRAM();
// if (CART_GetClearNVDirty())SaveCartNV();

/*static MDFN_COLD bool IsSaturnDisc(const uint8 *sa32k)
{
	//if(sha256(&sa32k[0x100], 0xD00) != "96b8ea48819cfa589f24c40aa149c224c420dccf38b730f00156efe25c9bbc8f"_sha256)
	// return false;

	if (memcmp(&sa32k[0], "SEGA SEGASATURN ", 16))
		return false;

	return true;
}*/
/*static MDFN_COLD bool TestMagicCD(std::vector<CDIF *> *CDInterfaces)
{
	std::unique_ptr<uint8[]> buf(new uint8[2048 * 16]);

	if ((*CDInterfaces)[0]->ReadSector(&buf[0], 0, 16, true) != 0x1)
		return false;

	return IsSaturnDisc(&buf[0]);
}*/

/*static MDFN_COLD void CloseGame(void)
{
 try { SaveBackupRAM(); } catch(std::exception& e) { MDFN_PrintError("%s", e.what()); }
 try { SaveCartNV();    } catch(std::exception& e) { MDFN_PrintError("%s", e.what()); }
 try { SaveRTC();	} catch(std::exception& e) { MDFN_PrintError("%s", e.what()); }

 Cleanup();
}*/

/*static MDFN_COLD void SaveBackupRAM(void)
{
 FileStream brs(MDFN_MakeFName(MDFNMKF_SAV, 0, "bkr"), FileStream::MODE_WRITE_INPLACE);

 brs.write(BackupRAM, sizeof(BackupRAM));

 brs.close();
}

static MDFN_COLD void LoadBackupRAM(void)
{
 FileStream brs(MDFN_MakeFName(MDFNMKF_SAV, 0, "bkr"), FileStream::MODE_READ);

 brs.read(BackupRAM, sizeof(BackupRAM));
}

static MDFN_COLD void BackupBackupRAM(void)
{
 MDFN_BackupSavFile(10, "bkr");
}

static MDFN_COLD void BackupCartNV(void)
{
 const char* ext = nullptr;
 void* nv_ptr = nullptr;
 uint64 nv_size = 0;

 CART_GetNVInfo(&ext, &nv_ptr, &nv_size);

 if(ext)
  MDFN_BackupSavFile(10, ext);
}*/

/*static MDFN_COLD void LoadCartNV(void)
{
 const char* ext = nullptr;
 void* nv_ptr = nullptr;
 uint64 nv_size = 0;

 CART_GetNVInfo(&ext, &nv_ptr, &nv_size);

 if(ext)
 {
  //FileStream nvs(MDFN_MakeFName(MDFNMKF_SAV, 0, ext), FileStream::MODE_READ);
  GZFileStream nvs(MDFN_MakeFName(MDFNMKF_SAV, 0, ext), GZFileStream::MODE::READ);

  nvs.read(nv_ptr, nv_size);
 }
}

static MDFN_COLD void SaveCartNV(void)
{
 const char* ext = nullptr;
 void* nv_ptr = nullptr;
 uint64 nv_size = 0;

 CART_GetNVInfo(&ext, &nv_ptr, &nv_size);

 if(ext)
 {
  //FileStream nvs(MDFN_MakeFName(MDFNMKF_SAV, 0, ext), FileStream::MODE_WRITE_INPLACE);
  GZFileStream nvs(MDFN_MakeFName(MDFNMKF_SAV, 0, ext), GZFileStream::MODE::WRITE);

  nvs.write(nv_ptr, nv_size);

  nvs.close();
 }
}*/

/*static MDFN_COLD void SaveRTC(void)
{
 FileStream sds(MDFN_MakeFName(MDFNMKF_SAV, 0, "smpc"), FileStream::MODE_WRITE_INPLACE);

 SMPC_SaveNV(&sds);

 sds.close();
}

static MDFN_COLD void LoadRTC(void)
{
 FileStream sds(MDFN_MakeFName(MDFNMKF_SAV, 0, "smpc"), FileStream::MODE_READ);

 SMPC_LoadNV(&sds);
}*/

int main()
{
	return 0;
}