using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class EmailMessagesDto
    {
        public string emailName { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
        public List<string> phrasesToChange { get; set; }
    }
}
