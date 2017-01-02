using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCryptoLibrary;

namespace RemeberBases
{
    delegate void TestDelegate(string str);

    delegate void StringModifier(ref string str);

    class Destruct
    {
        private int _x;
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public Destruct(int x)
        {
            X = x;
        }

        ~Destruct()
        {
            Console.WriteLine("{0} is finished!", X);
        }
    }

    class MyTestReloadConstructor
    {
        private string Message { get; set; }

        public MyTestReloadConstructor(string message)
        {
            Message = message;
        }

        public MyTestReloadConstructor() : this("I will tell this instead of you!")
        {

        }

        public void Show()
        {
            Console.WriteLine(Message);
        }
    }

    class StringModifierClass
    {
        public void PrintSomethingForMe(string s)
        {
            Console.WriteLine(s);
        }

        public void ReplaceSpaces(ref string str)
        {
            str = str.Replace(' ', '-');
        }

        public void ReverseString(ref string str)
        {
            string temp = "";
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                temp += str[j];
            }
            str = temp;
        }

        public void DeleteSpaces(ref string str)
        {
            string temp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                    temp += str[i];
            }
            str = temp;
        }
    }

    class Program
    {
        delegate int Incr(int c);

        static void EncryptionTest()
        {
            MyCrypto coder = new MyCrypto("Hello!"); //Create class for encoding/decodig and set the Key
            Console.WriteLine("Coder class is created with key {0}", coder.Key);

            string encryptString = "This is my string for encryption";
            Console.WriteLine("String for encryption is \"{0}\"", encryptString);

            string encrypted = coder.EncryptString(encryptString);
            Console.WriteLine("String after encryption as Hexidecimal numbers is \"{0}\"", encrypted);

            string decrypted = coder.DecryptHexString(encrypted);
            Console.WriteLine("String after DECRYPTION is \"{0}\"", decrypted);
        }

        static int MyFactorial(int number)
        {
            if (number == 1)
                return 1;
            else
            {
                return (number*MyFactorial(number - 1));
            }
        }

        static void OverloadOpers()
        {
            OverloadOperators f1 = new OverloadOperators(1, 2, 3);
            OverloadOperators f2 = new OverloadOperators(6, 7, 8);

            f1.Show();
            f2.Show();

            (f2 + f1).Show();
            (f2 - f1).Show();
            (f1 + 10).Show();

            OverloadOperators f3 = new OverloadOperators(1, 1, 0);
            OverloadOperators f4 = new OverloadOperators(0, 0, 0);

            Console.WriteLine(f3 ? "f3 is true" : "f3 is false");

            Console.WriteLine(f4 ? "f4 is true" : "f4 is false");

            int a = 3 + (int)f1;
            Console.WriteLine(a);
        }

        static void PropertiesAndIndicators()
        {
            PropsAndIndecsators mc = new PropsAndIndecsators();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(mc[i]);
            }

            Console.WriteLine(mc["first"]);
            Console.WriteLine(mc["Second"]);
            Console.WriteLine(mc["Third"]);
        }

        static void InterfacesTest()
        {
            MyClass mc = new MyClass();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(mc.GetNext());
            }
            mc.SetStart(14);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(mc.GetNext());
            }

            ((ISeries)mc).Reset();
            Console.WriteLine(mc.GetNext());
            Console.WriteLine("This is my next element {0}", mc[65]);

            Console.WriteLine(MyClass.MyEnum.Second + " " + (int)MyClass.MyEnum.Second);
        }

        static void ExceptionStest()
        {
            int i = 0;
            try
            {
                Console.WriteLine(12 / i);
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("Division by zero, {0}", ex.TargetSite);
            }
            finally
            {
                Console.WriteLine("Finally...");
            }
        }

        static void Something1()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                char tk = key.KeyChar;
                Console.WriteLine(tk);
                if (tk == 'q')
                    break;
            }

            char ch;
            do
            {
                ch = (char)Console.Read();
                if (ch == '\r')
                {
                    Console.Read();
                    break;
                }
                Console.WriteLine("Your symbol is {0}", ch);
            } while (true);
        }

        static void ReadFromFile()
        {
            Console.WriteLine("Enter file path");
            string filePath = Console.ReadLine();

            FileStream stream;

            try
            {
                stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
                Console.WriteLine("Cannot open file");
                return;
            }

            int i;
            long lostBytes = stream.Length;
            const int len = 100;
            try
            {
                do
                {
                    int bytesToRead = lostBytes > len ? len : (int)(lostBytes);
                    byte[] bytes = new byte[bytesToRead];
                    i = stream.Read(bytes, 0, bytesToRead);
                    lostBytes -= bytes.Length;
                    foreach (var b in bytes)
                    {
                        Console.Write((char)b);
                    }
                } while (i == len);
            }
            catch (IOException)
            {
                Console.WriteLine("There are some problems with file reading!");
                return;
            }
            finally
            {
                stream.Close();
            }

        }

        static void WriteToFile(string fileName)
        {
            byte[] tmpBytes = new byte[500];
            Random r = new Random(256);
            int i = 0;
            for (char c = 'A'; c < 'z'; c++, i++)
            {
                tmpBytes[i] = (byte) c;
            }
            
            FileStream fout = null;
            Console.WriteLine(fout);
            BinaryWriter sr = null; 

            try
            {
                fout = new FileStream(fileName, FileMode.Create);
                //fout.Write(tmpBytes, 0, tmpBytes.Length);
                //fout.Flush();
                sr = new BinaryWriter(fout);
                sr.Write(12.3);
                sr.Write("string");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                sr.Close();
                if (fout != null)   
                    fout.Close();
            }


            try
            {
                BinaryReader strR = new BinaryReader(new FileStream(fileName, FileMode.Open));
                //Console.WriteLine(strR.ReadString());
                Console.WriteLine(strR.ReadDouble());
                Console.WriteLine(strR.ReadString());
            }
            catch (Exception)
            {
                Console.WriteLine("End of file");
            }
        }

        static void PrintLine(string s)
        {
            Console.WriteLine(s);
        }

        static void Delegates1()
        {
            StringModifier d = null;
            StringModifierClass smc = new StringModifierClass();
            string s = "Hello world! My bro wanna drunk a little.";

            d += smc.DeleteSpaces;
            d += smc.ReverseString;
            d(ref s);
            Console.WriteLine(s);

            StringModifier mod1 = delegate (ref string s2)
            {
                Console.WriteLine(s2);
            };

            string l = "Hello from anonimus";
            mod1(ref l);
        }

        static void Delegates2()
        {
            Incr addOne = num => num += 2;
            Console.WriteLine(addOne(10));
        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Delegates2();

            Console.ReadLine();

            //WriteToFile(@"D:\my_test.dat");
            //ReadFromFile();
            //InterfacesTest();
            //EncryptionTest();
            //Console.WriteLine(MyFactorial(5));
            //OverloadOpers();

            /*
            BaseClass bc = new BaseClass();
            Inherited inh = new Inherited();
            SecondInherited sinh = new SecondInherited();

            bc.Who();
            inh.Who();
            sinh.Who();

            BaseClass t = new Inherited();
            t.Who();

            object ob = 10;
            */

            /*
            MyTestReloadConstructor tmp = new MyTestReloadConstructor("Hello world.");
            MyTestReloadConstructor tmp2 = new MyTestReloadConstructor();

            tmp.Show();
            tmp2.Show();
            */

            //Console.WriteLine("This method will return value to the call programm.");
            //return 42; // To check this value use "echo %ERRORLEVEL%"

            //Console.ReadLine();
        }
    }
}
