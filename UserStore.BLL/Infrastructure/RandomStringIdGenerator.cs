using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Forum_Marchuk.BLL.Infrastructure
{
    public static class RandomStringIdGenerator
    {
        private static readonly char[] charArr =
             "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public static string GetUniqueId()
        {
            byte[] data = new byte[4 * 128];
            using (RNGCryptoServiceProvider Randomiser = new RNGCryptoServiceProvider())
            {
                Randomiser.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(128);
            for (int i = 0; i < 128; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % charArr.Length;

                result.Append(charArr[idx]);
            }

            return result.ToString();
        }
    }
}
