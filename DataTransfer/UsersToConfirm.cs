using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class UsersToConfirmDto
    {
        public int userID { get; set; }
        public string generatedLinkHash { get; set; }
    }
}
