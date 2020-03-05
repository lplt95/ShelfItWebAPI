using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransfer;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDao
    {
        ShelfItBase database;
        WydawcaDao wydawcaDao;
        NotatkaDao notatkaDao;
        AutorDao autorDao;
        public BookDao()
        {
            database = new ShelfItBase();
            wydawcaDao = new WydawcaDao();
            notatkaDao = new NotatkaDao();
            autorDao = new AutorDao();
        }
        public List<KsiazkaDto> GetAllBooksForUser(UserDto user)
        {
            List<Ksiazka> ksiazkaList = new List<Ksiazka>();
            var repoList = user.repozytoria;
            foreach(var repo in repoList)
            {
                ksiazkaList = database.Ksiazka.Where(k => k.Pozycja.repozytorium_id == repo.repozytoriumID).ToList();
            }
            return ConvertToDto(ksiazkaList);
        }
        public KsiazkaDto GetBook(UserDto user, int? idKsiazka)
        {
            var ksiazka = database.Ksiazka.Single(k => k.id == idKsiazka);
            if (ksiazka == null) return null;
            if (!VerifyBook(ksiazka, user.repozytoria)) return null;
            return ConvertToDto(new List<Ksiazka>() { ksiazka }).FirstOrDefault();
        }
        public List<KsiazkaDto> AddBookToDatabase(KsiazkaDto ksiazka, UserDto user)
        {
            var position = new Pozycja()
            {
                id = database.Pozycja.Max(x => x.id) + 1,
                tytul = ksiazka.tytul,
                repozytorium_id = user.repozytoria.Find(x => x.dfltInd == "Y").repozytoriumID,
                rokWydania = ksiazka.rokWydania,
                typ = TypConst.Ksiazka,
            };
            var wydawca = database.Wydawca.Single(x => x.nazwa == ksiazka.wydawca);
            if (wydawca != null) position.wydawca = wydawca.id;
            else position.wydawca = wydawcaDao.AddWydawca(ksiazka.wydawca);
            if (ksiazka.notatka != null) position.notatka = notatkaDao.AddNotatka(ksiazka.notatka);
            if (ksiazka.ocena != null) position.ocena = ksiazka.ocena;
            database.Pozycja.Add(position);
            var book = new Ksiazka()
            {
                id = database.Ksiazka.Max(x => x.id) + 1,
                okladka = ksiazka.Okladka,
                iloscStron = ksiazka.IloscStron,
                pozycja_id = position.id
            };
            database.Ksiazka.Add(book);
            autorDao.ManageAutorsToPosition(ksiazka.autorzy, position.id);
            return GetAllBooksForUser(user);
        }
        #region PrivateHelpers
        private List<KsiazkaDto> ConvertToDto(List<Ksiazka> ksiazkaList)
        {
            List<KsiazkaDto> listaKsiazek = new List<KsiazkaDto>();
            foreach (var ksiazka in ksiazkaList)
            {
                List<AutorDto> listaAutorow = new List<AutorDto>();
                foreach(var autor in ksiazka.Pozycja.Autor_Pozycja)
                {
                    listaAutorow.Add(new AutorDto()
                    {
                        idAutora = autor.Autor.id,
                        Imie = autor.Autor.imie,
                        Nazwisko = autor.Autor.nazwisko
                    });
                }
                KsiazkaDto book = new KsiazkaDto()
                {
                    idPozycja = ksiazka.Pozycja.id,
                    idKsiazka = ksiazka.id,
                    IloscStron = ksiazka.iloscStron,
                    Okladka = ksiazka.okladka,
                    udostepnioneDla = ksiazka.Pozycja.udostepnioneDla,
                    tytul = ksiazka.Pozycja.tytul,
                    typ = ksiazka.Pozycja.Typ1.nazwa,
                    rokWydania = ksiazka.Pozycja.rokWydania,
                    repositoryID = ksiazka.Pozycja.repozytorium_id,
                    wydawca = ksiazka.Pozycja.Wydawca1.nazwa,
                    autorzy = listaAutorow
                };
                if(ksiazka.Pozycja.Notatka1 != null)
                {
                    book.notatka = ksiazka.Pozycja.Notatka1.tresc;
                }
                if(ksiazka.Pozycja.Ocena1 != null)
                {
                    book.ocena = ksiazka.Pozycja.Ocena1.ocena1;
                }
                listaKsiazek.Add(book);
            }
            return listaKsiazek;
        }
        private bool VerifyBook(Ksiazka ksiazka, List<RepozytoriumDto> repo)
        {
            var repository = repo.Find(x => x.repozytoriumID == ksiazka.Pozycja.repozytorium_id);
            if (repository != null) return true;
            else return false;
        }
        #endregion
    }
}
