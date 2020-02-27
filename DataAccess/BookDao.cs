using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransfer;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess
{
    public class BookDao
    {
        ShelfItBase database;
        public BookDao()
        {
            database = new ShelfItBase();
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
    }
}
