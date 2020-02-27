using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransfer;
using System.Threading.Tasks;

namespace DataAccess
{
    class AutorDao
    {
        ShelfItBase database;
        public AutorDao()
        {
            database = new ShelfItBase();
        }
        public int AddAutor(AutorDto autor)
        {
            var auth = new Autor()
            {
                id = database.Autor.Max(x => x.id) + 1,
                imie = autor.Imie,
                nazwisko = autor.Nazwisko
            };
            database.Autor.Add(auth);
            database.SaveChanges();
            return auth.id;
        }
        public void ManageAutorsToPosition(List<AutorDto> autorzy, int positionID)
        {
            foreach(var autor in autorzy)
            {
                var aut = database.Autor.Single(x => x.id == autor.idAutora);
                if (aut == null)
                {
                    aut = new Autor()
                    {
                        id = database.Autor.Max(x => x.id) + 1,
                        imie = autor.Imie,
                        nazwisko = autor.Nazwisko
                    };
                    database.Autor.Add(aut);
                }
                var autPos = new Autor_Pozycja()
                {
                    id = database.Autor_Pozycja.Max(x => x.id) + 1,
                    autor_id = aut.id,
                    pozycja_id = positionID
                };
                database.Autor_Pozycja.Add(autPos);
            }
            database.SaveChanges();
        }
    }
}
