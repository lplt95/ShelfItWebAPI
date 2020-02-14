using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class PozycjaDto
    {
        public int idPozycja { get; set; }
        public int repositoryID { get; set; }
        public string tytul { get; set; }
        public int rokWydania { get; set; }
        public int? udostepnioneDla { get; set; }
        public string typ { get; set; }
        public string notatka { get; set; }
        public int ocena { get; set; }
        public string wydawca { get; set; }
    }
}
