using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemeberBases
{
    class MyInheritas
    {
    }

    class BaseClass
    {
        internal double FirstBaseField;
        private double SecondBaseField;
        public int BaseProp { get; set; }
        private int SecBaseProp { get; set; }

        public BaseClass()
        {
            //Console.WriteLine("This is constructor for Base class");
        }

        public virtual void Who()
        {
            Console.WriteLine("Who in base class");
        }
    }

    class Inherited : BaseClass
    {
        public void DoSomething()
        {
            BaseProp = 3;
            FirstBaseField = 2.3;
        }

        public Inherited()
        {
            //Console.WriteLine("Inherited class constructor");
        }

        public override void Who()
        {
            Console.WriteLine("Who in inherited");
        }
    }

    class SecondInherited : BaseClass
    {
         
    }
}
