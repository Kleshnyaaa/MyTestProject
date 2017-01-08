using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ReflectionApp
{
    class A
    {
         
    }

    class B : A
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\assembly\";
            string path2 = @"System.dll";
            FileInfo fi = new FileInfo(path2);
            
            Console.WriteLine(fi.Exists);

            Assembly asm = Assembly.LoadFrom(path2);
            Console.WriteLine(asm.FullName);

            int i = 0;
            Type[] typesFromSystem = asm.GetTypes();
            //foreach (var type in typesFromSystem)
            //{
            //    //if (i++ == 100)
            //    //{
            //    //    i = 0;
            //    //    Console.ReadLine();
            //    //}
            //    if (type.FullName.Contains("Ping"))
            //    Console.WriteLine(type.FullName);
            //}

            Type pingType = asm.GetType("System.Net.NetworkInformation.Ping");
            Console.WriteLine(pingType.FullName + " " + pingType.Assembly);

            ConstructorInfo[] ci = pingType.GetConstructors();

            Console.WriteLine("There are some information about constructs. Total is {0}", ci.Length);
            foreach (var constrct in ci)
            {
                Console.WriteLine(constrct.Name);
                Console.WriteLine(constrct.Attributes);
                Console.WriteLine(constrct.IsAbstract);
                Console.WriteLine(constrct.IsStatic);
                ParameterInfo[] pi = constrct.GetParameters();
                Console.WriteLine("Number of parameters: {0}", pi.Length);
            }


            object obj = ci[0].Invoke(null);
            Console.WriteLine("Instance is created for " + obj.ToString());

            MethodInfo[] mi = pingType.GetMethods();
            foreach (var mthd in mi)
            {
                string str = "Position: " + i++;
                str += "(" + mthd.ReturnType.FullName + ")" + " " + mthd.Name + "(";
                ParameterInfo[] paramsInfo = mthd.GetParameters();
                foreach (var p in paramsInfo)
                {
                    str += p.ToString() + ", ";
                }
                str += ")";
                Console.WriteLine(str);
            }

            object pingResult = mi[4].Invoke(obj, new object[] {"google.ru", 10000});
            Console.WriteLine("Send method is invoked. Result has type: {0}", pingResult.GetType().FullName);
            Console.WriteLine(pingResult.GetType().GetProperty("Status").GetValue(pingResult, null));
            Console.WriteLine(pingResult.GetType().GetProperty("Address").GetValue(pingResult, null));

            //DirectoryInfo di = new DirectoryInfo(path);
            //Console.WriteLine(di.Exists);

            //FileInfo[] files = di.GetFiles();
            /*foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }*/

            #region First Test
            /*
            object ob = new object();
            A a = new A();
            B b = new B();
            A c = new B();

            Console.WriteLine(typeof(object));
            Console.WriteLine(typeof(A));
            Console.WriteLine(typeof(B));

            Console.WriteLine("Some type using GetType()");

            Console.WriteLine(ob.GetType().FullName + " " + ob.GetType().Assembly);
            Console.WriteLine(a.GetType().FullName + " " + a.GetType().Assembly);
            Console.WriteLine(b.GetType().FullName + " " + b.GetType().Assembly);
            Console.WriteLine(c.GetType().FullName + " " + c.GetType().Assembly);

            ob = a;
            Console.WriteLine(ob.GetType().FullName + " " + ob.GetType().Assembly);

            System.Reflection.MemberInfo memberInfo;
            memberInfo = typeof (StreamWriter);
            Console.WriteLine(memberInfo.GetType().MemberType);
    */
            #endregion

            Console.ReadLine();
        }
    }
}
