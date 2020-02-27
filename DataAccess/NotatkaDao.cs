using System;
using System.Collections.Generic;
using DataTransfer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class NotatkaDao
    {
        ShelfItBase database;
        public NotatkaDao()
        {
            database = new ShelfItBase();
        }
        public int AddNotatka(string tresc)
        {
            var notatka = new Notatka()
            {
                id = database.Notatka.Max(x => x.id) + 1,
                tresc = tresc,
                data = DateTime.Now
            };
            database.Notatka.Add(notatka);
            database.SaveChanges();
            return notatka.id;
        }
    }
}
