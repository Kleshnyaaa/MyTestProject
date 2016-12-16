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
            for (int i = 0; i < _key.Length; i++)
            {
                Console.Write("{0:X} ", _key[i]);
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
            set
            {
                char[] tmp = value.ToCharArray();
                _key = new byte[tmp.Length];
                for (int i = 0; i < _key.Length; i++)
                {
                    _key[i] = Convert.ToByte(tmp[i]);
                }
            }
        }

        public MyCrypto(string key)
        {
            Key = key;
        }
    }
}
