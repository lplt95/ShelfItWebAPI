using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace ShelfItService.DataRepositories
{
    public class BookRepository
    {
        public static List<KsiazkaDto> ksiazki = new List<KsiazkaDto>()
        {
        new KsiazkaDto()
            {
                idPozycja = 1,
                repositoryID = 2,
                notatka = "Książka do przeczytania",
                ocena = 5,
                Okladka = "Miękka",
                typ = TypConst.typKsiazka,
                wydawca = "Kupa s.p. z.o.o.",
                idKsiazka = 1,
                IloscStron = 100,
                tytul = "Książka na pewien temat",
                rokWydania = 2020,
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 1, Imie = "Jan", Nazwisko = "Kowalski"},
                    new AutorDto(){ idAutora = 2, Imie = "Marek", Nazwisko = "Nowak"}
                }
            },
            new KsiazkaDto()
            {
                idPozycja = 2,
                repositoryID = 1,
                notatka = "Ta książka jest dość średnia",
                ocena = 3,
                Okladka = "Twarda",
                typ = TypConst.typKsiazka,
                wydawca = "Wydawnictwo Testowe S.A.",
                idKsiazka = 2,
                IloscStron = 150,
                tytul = "Książka na inny temat",
                rokWydania = 2019,
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 1, Imie = "Jan", Nazwisko = "Kowalski"}
                }
            },
            new KsiazkaDto()
            {
                idPozycja = 3,
                repositoryID = 2,
                notatka = "To jest okropna książka!",
                ocena = 1,
                Okladka = "Miękka",
                typ = TypConst.typKsiazka,
                wydawca = "Wydajemy Szrot s.j.",
                idKsiazka = 3,
                IloscStron = 200,
                tytul = "To nawet nie jest książka...",
                rokWydania = 2018,
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 2, Imie = "Marek", Nazwisko = "Nowak"}
                }
            },
            new KsiazkaDto()
            {
                idPozycja = 10,
                repositoryID = 4,
                notatka = "Nie czytałem jeszcze, ale zapowiada się na całkiem niezłe gówno.",
                ocena = 1,
                Okladka = "Miękka",
                typ = TypConst.typKsiazka,
                wydawca = "PornoKsiążki sp. z.o.o.",
                idKsiazka = 4,
                IloscStron = 350,
                tytul = "365 dni",
                rokWydania = 2018,
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 3, Imie = "Ktoś", Nazwisko = "Nieznany"}
                }
            }
        };
        public bool VerifyBook(KsiazkaDto ksiazka, List<RepozytoriumDto> repo)
        {
            var repository = repo.Find(x => x.repozytoriumID == ksiazka.repositoryID);
            if (repository != null) return true;
            else return false;
        }
    }
}
