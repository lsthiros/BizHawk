//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


class LuaWrapPINVOKE {

  protected class SWIGExceptionHelper {

    public delegate void ExceptionDelegate(string message);
    public delegate void ExceptionArgumentDelegate(string message, string paramName);

    static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
    static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
    static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
    static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
    static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
    static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
    static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
    static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
    static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
    static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
    static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

    static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
    static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
    static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

    [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="SWIGRegisterExceptionCallbacks_LuaWrap")]
    public static extern void SWIGRegisterExceptionCallbacks_LuaWrap(
                                ExceptionDelegate applicationDelegate,
                                ExceptionDelegate arithmeticDelegate,
                                ExceptionDelegate divideByZeroDelegate, 
                                ExceptionDelegate indexOutOfRangeDelegate, 
                                ExceptionDelegate invalidCastDelegate,
                                ExceptionDelegate invalidOperationDelegate,
                                ExceptionDelegate ioDelegate,
                                ExceptionDelegate nullReferenceDelegate,
                                ExceptionDelegate outOfMemoryDelegate, 
                                ExceptionDelegate overflowDelegate, 
                                ExceptionDelegate systemExceptionDelegate);

    [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_LuaWrap")]
    public static extern void SWIGRegisterExceptionCallbacksArgument_LuaWrap(
                                ExceptionArgumentDelegate argumentDelegate,
                                ExceptionArgumentDelegate argumentNullDelegate,
                                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

    static void SetPendingApplicationException(string message) {
      SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArithmeticException(string message) {
      SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingDivideByZeroException(string message) {
      SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIndexOutOfRangeException(string message) {
      SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidCastException(string message) {
      SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidOperationException(string message) {
      SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIOException(string message) {
      SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingNullReferenceException(string message) {
      SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOutOfMemoryException(string message) {
      SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOverflowException(string message) {
      SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingSystemException(string message) {
      SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
    }

    static void SetPendingArgumentException(string message, string paramName) {
      SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArgumentNullException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentNullException(paramName, message));
    }
    static void SetPendingArgumentOutOfRangeException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
    }

    static SWIGExceptionHelper() {
      SWIGRegisterExceptionCallbacks_LuaWrap(
                                applicationDelegate,
                                arithmeticDelegate,
                                divideByZeroDelegate,
                                indexOutOfRangeDelegate,
                                invalidCastDelegate,
                                invalidOperationDelegate,
                                ioDelegate,
                                nullReferenceDelegate,
                                outOfMemoryDelegate,
                                overflowDelegate,
                                systemDelegate);

      SWIGRegisterExceptionCallbacksArgument_LuaWrap(
                                argumentDelegate,
                                argumentNullDelegate,
                                argumentOutOfRangeDelegate);
    }
  }

  protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

  public class SWIGPendingException {
    [global::System.ThreadStatic]
    private static global::System.Exception pendingException = null;
    private static int numExceptionsPending = 0;

    public static bool Pending {
      get {
        bool pending = false;
        if (numExceptionsPending > 0)
          if (pendingException != null)
            pending = true;
        return pending;
      } 
    }

    public static void Set(global::System.Exception e) {
      if (pendingException != null)
        throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
      pendingException = e;
      lock(typeof(LuaWrapPINVOKE)) {
        numExceptionsPending++;
      }
    }

    public static global::System.Exception Retrieve() {
      global::System.Exception e = null;
      if (numExceptionsPending > 0) {
        if (pendingException != null) {
          e = pendingException;
          pendingException = null;
          lock(typeof(LuaWrapPINVOKE)) {
            numExceptionsPending--;
          }
        }
      }
      return e;
    }
  }


  protected class SWIGStringHelper {

    public delegate string SWIGStringDelegate(string message);
    static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

    [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="SWIGRegisterStringCallback_LuaWrap")]
    public static extern void SWIGRegisterStringCallback_LuaWrap(SWIGStringDelegate stringDelegate);

    static string CreateString(string cString) {
      return cString;
    }

    static SWIGStringHelper() {
      SWIGRegisterStringCallback_LuaWrap(stringDelegate);
    }
  }

  static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


  static LuaWrapPINVOKE() {
  }


  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_delete_LuaCallback")]
  public static extern void delete_LuaCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaCallback_runCallback")]
  public static extern int LuaCallback_runCallback(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaCallback_runCallbackSwigExplicitLuaCallback")]
  public static extern int LuaCallback_runCallbackSwigExplicitLuaCallback(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_new_LuaCallback")]
  public static extern global::System.IntPtr new_LuaCallback();

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaCallback_director_connect")]
  public static extern void LuaCallback_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LuaCallback.SwigDelegateLuaCallback_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_delete_LuaHook")]
  public static extern void delete_LuaHook(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaHook_runHook")]
  public static extern int LuaHook_runHook(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2, System.IntPtr jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaHook_runHookSwigExplicitLuaHook")]
  public static extern int LuaHook_runHookSwigExplicitLuaHook(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2, System.IntPtr jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_new_LuaHook")]
  public static extern global::System.IntPtr new_LuaHook();

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaHook_director_connect")]
  public static extern void LuaHook_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LuaHook.SwigDelegateLuaHook_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_gc")]
  public static extern int LuaDLL_lua_gc(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_typename")]
  public static extern string LuaDLL_lua_typename(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_typename")]
  public static extern string LuaDLL_luaL_typename(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_error")]
  public static extern void LuaDLL_luaL_error(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_where")]
  public static extern void LuaDLL_luaL_where(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_newstate")]
  public static extern System.IntPtr LuaDLL_luaL_newstate();

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_close")]
  public static extern void LuaDLL_lua_close(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_openlibs")]
  public static extern void LuaDLL_luaL_openlibs(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_loadstring")]
  public static extern int LuaDLL_luaL_loadstring(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_dostring")]
  public static extern int LuaDLL_luaL_dostring(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_dostring")]
  public static extern int LuaDLL_lua_dostring(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_createtable")]
  public static extern void LuaDLL_lua_createtable(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_newtable")]
  public static extern void LuaDLL_lua_newtable(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_dofile")]
  public static extern int LuaDLL_luaL_dofile(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getglobal")]
  public static extern void LuaDLL_lua_getglobal(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_setglobal")]
  public static extern void LuaDLL_lua_setglobal(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_settop")]
  public static extern void LuaDLL_lua_settop(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pop")]
  public static extern void LuaDLL_lua_pop(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_insert")]
  public static extern void LuaDLL_lua_insert(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_remove")]
  public static extern void LuaDLL_lua_remove(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_gettable")]
  public static extern void LuaDLL_lua_gettable(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_rawget")]
  public static extern void LuaDLL_lua_rawget(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_settable")]
  public static extern void LuaDLL_lua_settable(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_rawset")]
  public static extern void LuaDLL_lua_rawset(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_newthread")]
  public static extern System.IntPtr LuaDLL_lua_newthread(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_resume")]
  public static extern int LuaDLL_lua_resume(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_yield")]
  public static extern int LuaDLL_lua_yield(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_setmetatable")]
  public static extern void LuaDLL_lua_setmetatable(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getmetatable")]
  public static extern int LuaDLL_lua_getmetatable(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_equal")]
  public static extern int LuaDLL_lua_equal(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushvalue")]
  public static extern void LuaDLL_lua_pushvalue(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_replace")]
  public static extern void LuaDLL_lua_replace(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_gettop")]
  public static extern int LuaDLL_lua_gettop(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_type")]
  public static extern int LuaDLL_lua_type(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_isnil")]
  public static extern bool LuaDLL_lua_isnil(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_isnumber")]
  public static extern bool LuaDLL_lua_isnumber(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_isboolean")]
  public static extern bool LuaDLL_lua_isboolean(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_ref")]
  public static extern int LuaDLL_luaL_ref(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_ref")]
  public static extern int LuaDLL_lua_ref(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_rawgeti")]
  public static extern void LuaDLL_lua_rawgeti(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_rawseti")]
  public static extern void LuaDLL_lua_rawseti(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_newuserdata")]
  public static extern System.IntPtr LuaDLL_lua_newuserdata(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_touserdata")]
  public static extern System.IntPtr LuaDLL_lua_touserdata(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getref")]
  public static extern void LuaDLL_lua_getref(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_unref")]
  public static extern void LuaDLL_lua_unref(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_isstring")]
  public static extern bool LuaDLL_lua_isstring(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_iscfunction")]
  public static extern bool LuaDLL_lua_iscfunction(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushnil")]
  public static extern void LuaDLL_lua_pushnil(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_call")]
  public static extern void LuaDLL_lua_call(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pcall")]
  public static extern int LuaDLL_lua_pcall(System.IntPtr jarg1, int jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_tonumber")]
  public static extern double LuaDLL_lua_tonumber(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_toboolean")]
  public static extern bool LuaDLL_lua_toboolean(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_tostring")]
  public static extern string LuaDLL_lua_tostring(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_atpanic")]
  public static extern void LuaDLL_lua_atpanic(System.IntPtr jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushstdcallcfunction")]
  public static extern void LuaDLL_lua_pushstdcallcfunction(System.IntPtr jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushnumber")]
  public static extern void LuaDLL_lua_pushnumber(System.IntPtr jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushboolean")]
  public static extern void LuaDLL_lua_pushboolean(System.IntPtr jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushstring")]
  public static extern void LuaDLL_lua_pushstring(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_newmetatable")]
  public static extern int LuaDLL_luaL_newmetatable(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getfield")]
  public static extern void LuaDLL_lua_getfield(System.IntPtr jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_getmetatable")]
  public static extern void LuaDLL_luaL_getmetatable(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_checkudata")]
  public static extern System.IntPtr LuaDLL_luaL_checkudata(System.IntPtr jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_getmetafield")]
  public static extern bool LuaDLL_luaL_getmetafield(System.IntPtr jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_loadbuffer")]
  public static extern int LuaDLL_luaL_loadbuffer(System.IntPtr jarg1, string jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_loadfile")]
  public static extern int LuaDLL_luaL_loadfile(System.IntPtr jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_error")]
  public static extern void LuaDLL_lua_error(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_checkstack")]
  public static extern bool LuaDLL_lua_checkstack(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_next")]
  public static extern int LuaDLL_lua_next(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_pushlightuserdata")]
  public static extern void LuaDLL_lua_pushlightuserdata(System.IntPtr jarg1, System.IntPtr jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luanet_rawnetobj")]
  public static extern int LuaDLL_luanet_rawnetobj(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_sethook")]
  public static extern int LuaDLL_lua_sethook(System.IntPtr jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_gethookmask")]
  public static extern int LuaDLL_lua_gethookmask(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_gethookcount")]
  public static extern int LuaDLL_lua_gethookcount(System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getstack")]
  public static extern int LuaDLL_lua_getstack(System.IntPtr jarg1, int jarg2, System.IntPtr jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getinfo")]
  public static extern int LuaDLL_lua_getinfo(System.IntPtr jarg1, string jarg2, System.IntPtr jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getlocal")]
  public static extern string LuaDLL_lua_getlocal(System.IntPtr jarg1, System.IntPtr jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_setlocal")]
  public static extern string LuaDLL_lua_setlocal(System.IntPtr jarg1, System.IntPtr jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_getupvalue")]
  public static extern string LuaDLL_lua_getupvalue(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_lua_setupvalue")]
  public static extern string LuaDLL_lua_setupvalue(System.IntPtr jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luanet_checkudata")]
  public static extern int LuaDLL_luanet_checkudata(System.IntPtr jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luaL_checkmetatable")]
  public static extern bool LuaDLL_luaL_checkmetatable(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luanet_gettag")]
  public static extern System.IntPtr LuaDLL_luanet_gettag();

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luanet_newudata")]
  public static extern void LuaDLL_luanet_newudata(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_LuaDLL_luanet_tonetobject")]
  public static extern int LuaDLL_luanet_tonetobject(System.IntPtr jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_new_LuaDLL")]
  public static extern global::System.IntPtr new_LuaDLL();

  [global::System.Runtime.InteropServices.DllImport("LuaWrap", EntryPoint="CSharp_delete_LuaDLL")]
  public static extern void delete_LuaDLL(global::System.Runtime.InteropServices.HandleRef jarg1);
}