using System;
using System.IO;
using System.Reflection;
using XNua;

namespace DarkSide
{
 public class LUA
 {
  private LuaState L = new LuaState();

  public void LoadScript(string name)
  {
   string path = ".\\Content\\";
   String fullPath = Path.GetFullPath(Path.GetDirectoryName(path));

   String[] scripts = Directory.GetFiles(fullPath, "*.lil");
   foreach (String s in scripts)
   {
    String scriptName = Path.GetFileNameWithoutExtension(s);
    if (scriptName != name) continue;

    Assembly assembly = Assembly.LoadFrom(s);

    Type mainClosure = assembly.GetType(scriptName + ".MainFunction");
    ConstructorInfo ctor = mainClosure.GetConstructor(new Type[] { typeof(LuaReference) });
    LuaClosure cl = (LuaClosure)ctor.Invoke(new Object[] { L.Globals });
    L.Stack[L.Stack.Top++] = cl;
    cl.Call(L, -1, 0);
   }
  }
  public void Init(string name, DEVICE_PACK ip)
  {
   LoadScript(name);
   DEVICE_PACK p = (DEVICE_PACK)L.Globals["p"].CLRObject;
   p.Init(ip);
  }
  public void Run(string name, DEVICE_PACK ip,string pname)
  {
   DEVICE_PACK p = (DEVICE_PACK)L.Globals[pname].CLRObject;
   p.Init(ip);
   p.gameList = ip.gameList;
   p.camera = ip.camera;
   LoadScript(name);
  }
  public Object getObject(string name)
  {
   return L.Globals[name].CLRObject;
  }

 }//class
}//namespace