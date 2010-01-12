using System;
using System.Reflection;
using XNua;
using System.IO;

namespace LuaTest
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            LuaTest test = new LuaTest();
            test.Run();
        }
    }
    // prints hello world + the parameter passed in and return 5.0
    public class SpecialHelloWorld : LuaFunction
    {
        public SpecialHelloWorld(LuaReference globals)
            : base(globals)
        {
        }

        public override int Execute(LuaState L)
        {
            int index = L.Stack.Base;
            int top = L.Stack.Top - 1;

            // retrieve the first parameter at index and turn it into a string
            // add hello world and trace it
            System.Diagnostics.Trace.Write("Hello World " + L.Stack[index].ToString() + "\n" );
            L.Stack[top] = 5.0; // a return value 
            return 1; // number of return values (lua can have multiple return values)
        }
    }

    public class LuaTest
    {
        private LuaState L = new LuaState();

        /// <summary>
        /// this loads all scripts (.lil files at the mo) in the path provided
        /// </summary>
        /// <param name="path"></param>
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
                    ConstructorInfo ctor = mainClosure.GetConstructor( new Type[] { typeof(LuaReference) } );
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

        public void Run()
        {
            // we use the fact that all files in the exe directory get copied
            // so we retrieve that and then load all the .LIL files hook them 
            // into the lua state and viola we have a bunch of Lua functions
            // and tables ready to go :D
            String fullPath = ".\\";
            LoadScripts(fullPath); 

            // static binding example
            // rename .lil file to dll, add Reference to the project
            // then access like any c# assembly
            // then call like so
/*            LuaClosure co = new sieve.MainFunction(L.Globals);
            L.Stack[L.Stack.Top++] = co;
            co.Call(L, -1, 0);*/

            // call lua print from C#
            LuaFunction print = (LuaFunction)L.Globals["print"].O;
            print.Call(new Object[] { "Hello World" });

            // insert our special hello world as Hello_World
            L.Globals["Hello_World"] = new SpecialHelloWorld(L.Globals);

            // set some variables in the Lua state
            L.Globals["my_name"] = "DeanoC";
            L.Globals["my_iq"] = -5.0f;
            
            LuaFunction name_iq = (LuaFunction)L.Globals["PrintNameAndIQ"].O;
            name_iq.Call(new Object[] { });

            Console.Write("END");

        }
    }
}
