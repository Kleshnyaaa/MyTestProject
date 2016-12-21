using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemeberBases
{
    public class OverloadOperators
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public OverloadOperators(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Show()
        {
            Console.WriteLine("My coordinates are: X = {0}, Y = {1}, Z = {2}", X, Y, Z);
        }

        public static OverloadOperators operator +(OverloadOperators ob1, OverloadOperators ob2)
        {
            return new OverloadOperators(ob1.X + ob2.X, ob1.Y + ob2.Y, ob1.Z + ob2.Z);
        }

        public static OverloadOperators operator -(OverloadOperators ob1, OverloadOperators ob2)
        {
            return new OverloadOperators(ob1.X - ob2.X, ob1.Y - ob2.Y, ob1.Z - ob2.Z);
        }

        public static OverloadOperators operator +(OverloadOperators ob1, int n)
        {
            return new OverloadOperators(ob1.X + n, ob1.Y + n, ob1.Y + n);
        }

        public static bool operator true(OverloadOperators ob1)
        {
            if (ob1.X != 0 || ob1.Y != 0 || ob1.Z != 0)
                return true;
            else
            {
                return false;
            }
        }

        public static bool operator false(OverloadOperators ob1)
        {
            if (ob1.X == 0 && ob1.Y == 0 && ob1.Z == 0)
                return true;
            else
            {
                return false;
            }
        }

        public static explicit operator int(OverloadOperators ob1)
        {
            return ob1.X * ob1.Y * ob1.Z;
        }
    }
}
