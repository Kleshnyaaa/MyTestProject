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

        public int this[int i] 
        {
            get { return i*10; }
            set { _justForFun = i; }
        }
    }
}
