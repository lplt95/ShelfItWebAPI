using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class RepozytoriumDao
    {
        ShelfItBase database;
        public RepozytoriumDao()
        {
            database = new ShelfItBase();
        }
        public bool AddDefaultRepoForUser(int userID)
        {
            if (database.Repozytorium.Single(x => x.uzytkownik_id == userID && x.numer_repoz == 1) != null) return false;
            var repo = new Repozytorium()
            {
                id = database.Repozytorium.Max(x => x.id) + 1,
                uzytkownik_id = userID,
                nazwa = "Default",
                numer_repoz = 1,
                domyslny_id = "Y",
            };
            database.Repozytorium.Add(repo);
            database.SaveChanges();
            return true;
        }
    }
}
