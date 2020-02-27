using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class RepozytoriumDto
    {
        public int repozytoriumID { get; set; }
        public int wlascicielID { get; set; }
        public string nazwa { get; set; }
        public string dfltInd { get; set; }
        //repoNumber odnosi się do numeru kolejnego repozytorium danego użytkownika,
        //tnz. repoNumber = 2 oznacza, że jest to drugie repozytorium danego użytkownika
        public int repoNumber { get; set; }
    }
}
