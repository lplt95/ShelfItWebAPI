using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class WydawcaDao
    {
        ShelfItBase database;
        public WydawcaDao()
        {
            database = new ShelfItBase();
        }
        public int AddWydawca(string nazwaWydawca)
        {
            var wyd = new Wydawca()
            {
                id = database.Wydawca.Max(x => x.id) + 1,
                nazwa = nazwaWydawca
            };
            database.Wydawca.Add(wyd);
            database.SaveChanges();
            return wyd.id;
        }
    }
}
