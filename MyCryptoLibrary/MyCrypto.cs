using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCryptoLibrary
{
    public class MyCrypto
    {
        private int[] _key;

        public string Key
        {
            get
            {
                return this.ConvertIntArrayToUnicodeString(_key);
            }
            set { _key = this.StringToIntArray(value); }
        }

        public MyCrypto(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Present each symbol as Unicode number
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int[] StringToIntArray(string str) //Present each symbol as Unicode number
        {
            char[] tmp = str.ToCharArray();
            int[] result = new int[tmp.Length];

            for (int i = 0; i < tmp.Length; i++)
            {
                result[i] = Convert.ToInt32(tmp[i]);
            }

            return result;
        }

        /// <summary>
        /// Convert array of int codes to Unicode string
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private string ConvertIntArrayToUnicodeString(int[] arr)
        {
            string tmp = "";
            foreach (int b in arr)
            {
                tmp += Convert.ToChar(b);
            }
            return tmp;
        } 

        public string GetHexString(int[] arr)
        {
            string tmp = "";
            foreach (int i in arr)
            {
                tmp += i.ToString("X") + " ";
            }
            return tmp.TrimEnd(new char[] {' '});
        }

        /// <summary>
        /// Present each hex string value separated by space as int array element
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int[] HexStringToIntArray(string str)
        {
            string[] bytes = str.Split(new char[] {' '});
            int[] result = new int[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                result[i] = Convert.ToInt32(bytes[i], fromBase: 16);
            }
            return result;
        }

        /// <summary>
        /// Apply operator ^ with key for set array
        /// </summary>
        /// <param name=""></param>
        private void Annihilation(int[] array) 
        {
            int i = 0;
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = array[j] ^ _key[i];
                i++;
                if (i == _key.Length)
                {
                    i = 0;
                }
            }
        }

        public string EncryptString(string str)
        {
            int[] intArrayForEncription = this.StringToIntArray(str);

            this.Annihilation(intArrayForEncription);

            return this.GetHexString(intArrayForEncription);
        }

        public string DecryptHexString(string str)
        {
            int[] dataForDecription = this.HexStringToIntArray(str);
            this.Annihilation(dataForDecription);
            return this.ConvertIntArrayToUnicodeString(dataForDecription);

            //throw new NotImplementedException();
        }
    }
}
