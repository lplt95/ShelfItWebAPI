using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class UserDto
    {
        public int userID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public List<RepozytoriumDto> repozytoria { get; set; }
        public string sessionID { get; private set; }
        public void GenerateID()
        {
            var date = DateTime.Today;
            int variable = date.Year + date.Month + date.Day + new Random().Next();
            string toHash = login + variable;
            MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
            byte[] _data = md5Crypto.ComputeHash(Encoding.Default.GetBytes(toHash));
            StringBuilder _sBulider = new StringBuilder();
            for (int i = 0; i < _data.Length; i++)
            {
                _sBulider.Append(_data[i].ToString("x2"));
            }
            sessionID = _sBulider.ToString();
        }
    }
}
