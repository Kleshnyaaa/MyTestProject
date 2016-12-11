using System;

namespace MyStackProgram
{
    class MyStack
    {
        /*
         * Стек:
- Добавление (Push)
- Извлечение (Pop)
- bool IsEmpty
- bool IsFull
- Общая емкость
- Насколько заполнен
*/

        private int[] Elements { get; set; }
        private int Tail { get; set; }

        public MyStack(int capacity)
        {
            Elements = new int[capacity];
            Tail = 0;
        }

        public void Push(int num) // Add new element into stack
        {
            if (Tail >= Elements.Length)
            {
                throw new Exception("Stack is full. Element is not added.");
            }

            Elements[Tail] = num;
            Tail++;
        }

        public int Pop() // Get element from stack
        {
            if (Tail == 0)
            {
                throw new Exception("Stack is empty. There is no Elements to return.");
            }

            Tail--;
            return Elements[Tail];
        }

        public bool IsEmpty()
        {
            return Tail == 0;
        }

        public bool IsFull()
        {
            return Tail == Elements.Length;
        }

        public int GetGeneralCapacity()
        {
            return Elements.Length;
        }

        public int GetCurrentNumberOfElement()
        {
            return Tail;
        }
    }
}
