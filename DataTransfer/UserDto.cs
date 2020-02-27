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
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public List<RepozytoriumDto> repozytoria { get; set; }
        public string sessionID { get; set; }
        public bool IsConfirmed { get; set; }
    }
    public class ChangePass
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public int userID { get; set; }
    }
}
