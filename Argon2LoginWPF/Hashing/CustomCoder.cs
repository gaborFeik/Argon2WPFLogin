using System;
using System.Text;

namespace Argon2LoginWPF.Hashing
{
    public class CustomCoder
    {
        /// <summary>
        /// Decode byte[] to String static method
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public static string ByteArrayTostring(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        /// <summary>
        /// Encode hex string into byte[]
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i+=2)           
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
