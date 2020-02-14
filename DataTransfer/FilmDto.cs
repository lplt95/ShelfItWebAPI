using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class FilmDto : PozycjaDto
    {
        public int idFilm { get; set; }
        public int DlugoscTrwania { get; set; }
    }
}
 