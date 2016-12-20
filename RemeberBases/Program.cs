using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCryptoLibrary;

namespace RemeberBases
{
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

    class Program
    {
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

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            EncryptionTest();

            Console.ReadLine();

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
