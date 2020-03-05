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
        public bool AddRepoForUser(int userID, string name)
        {
            var repo = new Repozytorium()
            {
                id = database.Repozytorium.Max(x => x.id) + 1,
                uzytkownik_id = userID,
                nazwa = name,
                numer_repoz = database.Repozytorium.Where(r => r.uzytkownik_id == userID).Max(x => x.numer_repoz) + 1,
                domyslny_id = "N"
            };
            database.Repozytorium.Add(repo);
            database.SaveChanges();
            return true;
        }
        public bool SetRepoAsDefault(int repoID, int userID)
        {
            var oldDefault = database.Repozytorium.Single(x => x.uzytkownik_id == userID && x.domyslny_id == "Y");
            var newDefault = database.Repozytorium.Single(x => x.uzytkownik_id == userID && x.id == repoID);
            if (newDefault == null) return false;
            oldDefault.domyslny_id = "N";
            newDefault.domyslny_id = "Y";
            database.SaveChanges();
            return true;
        }
        public bool ShareRepoToUser(int repoID, int ownerID, int userID)
        {
            var repoToShare = database.Repozytorium.Single(x => x.uzytkownik_id == ownerID && x.id == repoID);
            if (repoToShare == null) return false;
            var sharedEntry = new Repozytorium_Udostepnienie()
            {
                udostepnienie_id = database.Repozytorium_Udostepnienie.Max(x => x.udostepnienie_id),
                repozytorium_id = repoToShare.id,
                wlasciciel_id = ownerID,
                uzytkownik_id = userID
            };
            database.Repozytorium_Udostepnienie.Add(sharedEntry);
            database.SaveChanges();
            return true;
        }
        public bool DeleteUserRepo(int repoID, int userID)
        {
            var repoToDelete = database.Repozytorium.Single(x => x.id == repoID && x.uzytkownik_id == userID);
            if (repoToDelete == null) return false;
            database.Repozytorium.Remove(repoToDelete);
            database.SaveChanges();
            return true;
        }
    }
}
