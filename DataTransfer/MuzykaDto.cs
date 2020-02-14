using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class MuzykaDto : PozycjaDto
    {
        public int idMuzyka { get; set; }
        public int IloscSciezek { get; set; }
        public int IloscPlyt { get; set; }
    }
}
