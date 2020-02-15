using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace ShelfItService.DataRepositories
{
    public class FilmRepository
    {
        public List<FilmDto> filmy;
        public FilmRepository()
        {
            filmy = new List<FilmDto>();
            CreateList();
        }
        private void CreateList()
        {
            filmy.Add(new FilmDto()
            {
                idFilm = 1, 
                idPozycja = 7, 
                repositoryID = 2,
                DlugoscTrwania = 150,
                notatka = "Film taki sobie.",
                ocena = 2,
                rokWydania = 2019,
                typ = TypConst.typFilm,
                tytul = "Justice League",
                wydawca = "Sony",
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 7, Imie = "Reżyser", Nazwisko = "Nieznany"}
                }
            });
            filmy.Add(new FilmDto()
            {
                idFilm = 2, 
                idPozycja = 8, 
                repositoryID = 4,
                DlugoscTrwania = 180,
                notatka = "Fajne",
                ocena = 4,
                rokWydania = 2020,
                typ = TypConst.typFilm,
                tytul = "Piękna i Bestia",
                wydawca = "Disney",
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 8, Imie = "Ktoś", Nazwisko = "Tam"}
                }
            });
            filmy.Add(new FilmDto()
            {
                idFilm = 3,
                idPozycja = 9, 
                repositoryID = 2,
                DlugoscTrwania = 90,
                notatka = "",
                ocena = 3,
                rokWydania = 2010,
                typ = TypConst.typFilm,
                tytul = "TO",
                wydawca = "Sony",
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 9, Imie = "Jacek", Nazwisko = "Bursztyn"}
                }
            });
        }
        public bool VerifyFilm(FilmDto film, List<RepozytoriumDto> repo)
        {
            var repository = repo.Find(x => x.repozytoriumID == film.repositoryID);
            if (repository != null) return true;
            else return false;
        }
    }
}
