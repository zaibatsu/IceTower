using System;
using System.Reflection;
using XNua;
using System.IO;

namespace DarkSide
{
 class LuaTest
 {
  private LuaState L = new LuaState();
  private void LoadScripts(string path)
  {
   String fullPath = Path.GetFullPath(Path.GetDirectoryName(path));

   String[] scripts = Directory.GetFiles(fullPath, "*.lil");
   foreach (String s in scripts)
   {
    String scriptName = Path.GetFileNameWithoutExtension(s);

    try
    {
     Assembly assembly = Assembly.LoadFrom(s);

     Type mainClosure = assembly.GetType(scriptName + ".MainFunction");
     ConstructorInfo ctor = mainClosure.GetConstructor(new Type[] { typeof(LuaReference) });
     LuaClosure cl = (LuaClosure)ctor.Invoke(new Object[] { L.Globals });
     L.Stack[L.Stack.Top++] = cl;
     cl.Call(L, -1, 0);
    }
#if !XBOX360
    catch (ReflectionTypeLoadException rtle)
    {
     Console.Write("Error loading script {0} - ReflectionTypeLoad Error ", s);
     foreach (Exception e in rtle.LoaderExceptions)
     {
      Console.Write(e.Message);
     }
    }
#endif
    catch (ArgumentException e)
    {
     Console.Write("Error loading or running script {0}\n {1}\n", s, e.Message);
     Console.Write("Stack Trace: {0}\n", e.StackTrace);
    }
    catch (Exception e)
    {
#if !XBOX360
     Console.Write("Error loading or running script {0}\n {1}\n {2}\n", s, e.Message, e.Source);
     Console.Write("Stack Trace: {0}\n", e.StackTrace);
#else
                    Console.Write("Error loading or running script {0}\n {1}\n", s, e.Message);
                    Console.Write("Stack Trace: {0}\n", e.StackTrace);
#endif
    }
   }
  }

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

  public void Run(DEVICE_PACK ip)
  {
   LoadScript("init");

   DEVICE_PACK dp = (DEVICE_PACK)L.Globals["dp"].CLRObject;
   dp.Init(ip);
   dp.objList = ip.objList;

   LoadScript("addMesh");
   int quit = 0;
  }

 }//class
}//namespace