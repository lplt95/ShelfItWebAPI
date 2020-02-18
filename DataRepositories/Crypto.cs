using System;
using System.Text;
using System.Security.Cryptography;

namespace DataRepositories
{
    public class Crypto
    {
        /// <summary>
        /// Preparing hash of string using SHA-512
        /// </summary>
        /// <param name="input">String to hash</param>
        /// <returns></returns>
        public string GetHash(string input)
        {
            MD5CryptoServiceProvider _shaCrypto = new MD5CryptoServiceProvider();
            byte[] _data = _shaCrypto.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder _sBulider = new StringBuilder();
            for (int i = 0; i < _data.Length; i++)
            {
                _sBulider.Append(_data[i].ToString("x2"));
            }
            return _sBulider.ToString();
        }
        /// <summary>
        /// Veryfing if one hash is compare to second one.
        /// </summary>
        /// <param name="input">Inputed string to hash</param>
        /// <param name="hash">The hashed one</param>
        /// <returns>True if strings are compare, false if not.</returns>
        public bool VerifyHash (string input, string hash)
        {
            string _hashOfInput = GetHash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(_hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
