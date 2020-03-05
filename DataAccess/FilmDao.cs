using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer;

namespace DataAccess
{
    public class FilmDao
    {
        ShelfItBase database;
        WydawcaDao wydawcaDao;
        NotatkaDao notatkaDao;
        AutorDao autorDao;
        public FilmDao()
        {
            database = new ShelfItBase();
            wydawcaDao = new WydawcaDao();
            notatkaDao = new NotatkaDao();
            autorDao = new AutorDao();
        }
        public List<FilmDto> GetAllFilmsForUser(UserDto user)
        {
            List<Film> filmList = new List<Film>();
            var repoList = user.repozytoria;
            foreach (var repo in repoList)
            {
                filmList = database.Film.Where(f => f.Pozycja.repozytorium_id == repo.repozytoriumID).ToList();
            }
            return ConvertToDto(filmList);
        }
        public FilmDto GetMovie(UserDto user, int? idFilm)
        {
            var film = database.Film.Single(f => f.id == idFilm);
            if (film == null) return null;
            if (!VerifyMovie(film, user.repozytoria)) return null;
            return ConvertToDto(new List<Film>() { film }).FirstOrDefault();
        }
        public List<FilmDto> AddFilmToDatabase(FilmDto film, UserDto user)
        {
            var position = new Pozycja()
            {
                id = database.Pozycja.Max(x => x.id) + 1,
                tytul = film.tytul,
                repozytorium_id = user.repozytoria.Find(x => x.dfltInd == "Y").repozytoriumID,
                rokWydania = film.rokWydania,
                typ = TypConst.Ksiazka,
            };
            var wydawca = database.Wydawca.Single(x => x.nazwa == film.wydawca);
            if (wydawca != null) position.wydawca = wydawca.id;
            else position.wydawca = wydawcaDao.AddWydawca(film.wydawca);
            if (film.notatka != null) position.notatka = notatkaDao.AddNotatka(film.notatka);
            if (film.ocena != null) position.ocena = film.ocena;
            database.Pozycja.Add(position);
            var movie = new Film()
            {
                id = database.Film.Max(x => x.id) + 1,
                dlugoscTrwania = film.DlugoscTrwania,
                pozycja_id = position.id
            };
            database.Film.Add(movie);
            autorDao.ManageAutorsToPosition(film.autorzy, position.id);
            return GetAllFilmsForUser(user);
        }
        #region PrivateHelpers
        private List<FilmDto> ConvertToDto(List<Film> filmList)
        {
            List<FilmDto> listaFilmow = new List<FilmDto>();
            foreach (var film in filmList)
            {
                List<AutorDto> listaAutorow = new List<AutorDto>();
                foreach (var autor in film.Pozycja.Autor_Pozycja)
                {
                    listaAutorow.Add(new AutorDto()
                    {
                        idAutora = autor.Autor.id,
                        Imie = autor.Autor.imie,
                        Nazwisko = autor.Autor.nazwisko
                    });
                }
                FilmDto movie = new FilmDto()
                {
                    idPozycja = film.Pozycja.id,
                    idFilm = film.id,
                    DlugoscTrwania = film.dlugoscTrwania,
                    udostepnioneDla = film.Pozycja.udostepnioneDla,
                    tytul = film.Pozycja.tytul,
                    typ = film.Pozycja.Typ1.nazwa,
                    rokWydania = film.Pozycja.rokWydania,
                    repositoryID = film.Pozycja.repozytorium_id,
                    wydawca = film.Pozycja.Wydawca1.nazwa,
                    autorzy = listaAutorow
                };
                if (film.Pozycja.Notatka1 != null)
                {
                    movie.notatka = film.Pozycja.Notatka1.tresc;
                }
                if (film.Pozycja.Ocena1 != null)
                {
                    movie.ocena = film.Pozycja.Ocena1.ocena1;
                }
                listaFilmow.Add(movie);
            }
            return listaFilmow;
        }
        private bool VerifyMovie(Film film, List<RepozytoriumDto> repo)
        {
            var repository = repo.Find(x => x.repozytoriumID == film.Pozycja.repozytorium_id);
            if (repository != null) return true;
            else return false;
        }
        #endregion
    }
}
