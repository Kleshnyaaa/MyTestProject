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

    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[100];
            Console.WriteLine(myArray.Length);
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = i;
                Console.WriteLine("i = {0}, array's element = {1}", i, myArray[i]);
            }


            Console.WriteLine("The end!");
            Console.ReadLine();
        }
    }
}
