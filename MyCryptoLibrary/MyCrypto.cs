using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCryptoLibrary
{
    public class MyCrypto
    {
        private byte[] _key;

        //delete this method later
        public void PrintKeyArray()
        {
            foreach (byte b in _key)
            {
                Console.Write("{0:X} ", b);
            }

            Console.WriteLine();
        }

        public string Key
        {
            get
            {
                string tmp = "";
                foreach (byte b in _key)
                {
                    tmp += Convert.ToChar(b);
                }

                return tmp;
            }
            set { _key = this.StringToByteArray(value); }
        }

        public MyCrypto(string key)
        {
            Key = key;
        }

        private byte[] StringToByteArray(string str)
        {
            char[] tmp = str.ToCharArray();
            byte[] result = new byte[tmp.Length];

            for (int i = 0; i < tmp.Length; i++)
            {
                result[i] = Convert.ToByte(tmp[i]);
            }

            return result;
        }

        //delete this method
        public void ShowAllUnicodeSimbols()
        {
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine("Dec: {0:D} - Hex: {1:X} - Char: {2}", i, i, Convert.ToChar(i));
            }
        }
    }
}
