using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCryptography
{
    class Crypto
    {
        private string _key ;

        private string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public Crypto(string key)
        {
            Key = key;
        }

        public string Encrypt(string toEncrypt)
        {
            int tmp = int.Parse(toEncrypt) ^ byte.Parse(Key);

        }
    }
}
