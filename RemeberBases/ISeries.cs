using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemeberBases
{
    
    interface ISeries
    {
        int GetNext();
        void SetStart(int n);
        void Reset();
        int GetCurrentValue();

        int this[int index] { get; set; }
    }

    class MyClass : ISeries
    {
        public enum MyEnum
        {
            First,
            Second,
            Third,
            Fourth
        }

        private int _currentValue;
        private int _start;

        public MyClass()
        {
            _currentValue = 0;
            _start = 0;
        }

        public int GetNext()
        {
            _currentValue += 3;
            return _currentValue;
        }

        public void SetStart(int n)
        {
            _start = n;
            _currentValue = _start;
        }

        void ISeries.Reset()
        {
            _currentValue = _start;
        }

        public int GetCurrentValue()
        {
            return _currentValue;
        }

        public int this[int index]
        {
            get
            {
                int tmp = 0;
                for (int i = 0; i < index; i++)
                {
                    tmp += 2;
                }
                return tmp;
            }
            set
            {
                Console.WriteLine("The value {0} should be set", value);
            }
        }
    }
}
