using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTests
{
    delegate void MyEventHandler(string str);

    class EventGeneratedClass
    {
        public event MyEventHandler MyEvent;

        public void DoSomething()
        {
            if (MyEvent != null) MyEvent.Invoke("Hello");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EventGeneratedClass myClass = new EventGeneratedClass();
            myClass.MyEvent += (string s) => Console.WriteLine("Method via lambds");
            myClass.DoSomething();
            Console.ReadLine();
        }
    }
}
