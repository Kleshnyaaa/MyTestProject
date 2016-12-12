using System;

namespace MyStackProgram
{
    class Program
    {
        public static void PrintStackElements(MyStackGeneric<int> s)
        {
            while (!s.IsEmpty())
            {
                Console.Write("{0, 3}", s.Pop());
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            MyStackGeneric<int> stack = new MyStackGeneric<int>(10);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("On position {0} added element {1}", i, (i + 1) * 2);
                stack.Push((i + 1) * 2);
            }

            Console.WriteLine();
            Console.WriteLine("Before print.");
            Console.WriteLine("General capacity: {0}", stack.GetGeneralCapacity());
            Console.WriteLine("Current capacity: {0}", stack.GetCurrentCapacity());
            Console.WriteLine("Is stack full? - {0}", stack.IsFull());
            Console.WriteLine("Is stack empty? - {0}", stack.IsEmpty());

            try
            {
                stack.Push(3);
            }
            catch (MyStackException)
            {
                Console.WriteLine("I've cought exception: {0}", stack.GetCurrentCapacity());
            }

            PrintStackElements(stack);

            try
            {
                stack.Pop();
            }
            catch (MyStackException)
            {
                Console.WriteLine("I've cought exception again: {0}", stack.GetCurrentCapacity());
            }

            Console.WriteLine();
            Console.WriteLine("After print.");
            Console.WriteLine("General capacity: {0}", stack.GetGeneralCapacity());
            Console.WriteLine("Current capacity: {0}", stack.GetCurrentCapacity());
            Console.WriteLine("Is stack full? - {0}", stack.IsFull());
            Console.WriteLine("Is stack empty? - {0}", stack.IsEmpty());
            Console.ReadLine();
        }
    }
}
