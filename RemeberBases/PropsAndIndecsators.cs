using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemeberBases
{
    public class PropsAndIndecsators
    {
        int _justForFun;
        string _strFun;

        public int this[int i] 
        {
            get { return i*10; }
            set { _justForFun = i; }
        }

        public string this[string index]
        {
            get
            {
                string result = index + " is your element";
                return result;
            }
            set { _strFun = value; }
        }

        public int MyIntProp { get; }

        public void DoSomething()
        {
            Console.WriteLine(MyIntProp);
        }
    }
}
