using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static int Main(string[] args)
        {
            /*
            MyTestReloadConstructor tmp = new MyTestReloadConstructor("Hello world.");
            MyTestReloadConstructor tmp2 = new MyTestReloadConstructor();

            tmp.Show();
            tmp2.Show();
            */

            Console.WriteLine("This method will return value to the call programm.");
            return 42; // To check this value use "echo %ERRORLEVEL%"

            //Console.ReadLine();
        }
    }
}
