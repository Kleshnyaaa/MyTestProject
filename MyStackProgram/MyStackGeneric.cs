using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackProgram
{
    public class MyStackException : Exception
    {
        public MyStackException(string message) : base(message)
        {
            
        }
    }

    public class MyStackGeneric<T>
    {
        private int Top { get; set; }
        private int MaxSize { get; set; }
        private T[] Items { get; set; }

        public MyStackGeneric(int size)
        {
            MaxSize = size;
            Items = new T[MaxSize];
            Top = 0;
        } 

        //Push
        public void Push(T value)
        {
            if (IsFull())
            {
                throw new MyStackException("Stack is full. Element is not added.");
            }

            Items[Top] = value;
            Top++;
        }
        
        //Pop
        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new MyStackException("Stack is empty. No elements are retrieved.");
            }
            Top--;
            return Items[Top];
        }

        //IsFull
        public bool IsFull()
        {
            return Top == MaxSize;
        }

        //IsEmty
        public bool IsEmpty()
        {
            return Top == 0;
        }

        //GetCurrentCapacity
        public int GetCurrentCapacity()
        {
            return Top;
        }

        //GetGeneralCapacity
        public int GetGeneralCapacity()
        {
            return MaxSize;
        }
    }
}
