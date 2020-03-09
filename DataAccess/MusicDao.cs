
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataTransfer;

namespace DataAccess
{
   public class MusicDao
    {
        ShelfItBase database;
        WydawcaDao wydawcaDao;
        NotatkaDao notatkaDao;
        AutorDao autorDao;

        public MusicDao()
        {
            database = new ShelfItBase();
            wydawcaDao = new WydawcaDao();
            notatkaDao = new NotatkaDao();
            autorDao = new AutorDao();
        }

        public List<MuzykaDto> GetAllMusicForUser(UserDto user)
        {
            List<Muzyka> muzykaList = new List<Muzyka>();
            var repoList = user.repozytoria;
            foreach(var repo in repoList)
            {
                muzykaList = database.Muzyka.Where(k => k.Pozycja.repozytorium_id == repo.repozytoriumID).ToList();

            }
            return ConvertToDto(muzykaList);
        }

        public MuzykaDto GetMusic(UserDto user, int? idMuzyka)
        {
            var muzyka = database.Muzyka.Single(k => k.id == idMuzyka);
            if (muzyka == null) return null;
            if (!VerifyMusic(muzyka, user.repozytoria)) return null;
            return ConvertToDto(new List<Muzyka>() { muzyka }).FirstOrDefault();
        }

        public List<MuzykaDto> AddMusicToDatabase(MuzykaDto muzyka, UserDto user)
        {
            var position = new Pozycja()
            {
                id = database.Pozycja.Max(x => x.id) + 1,
                tytul = muzyka.tytul,
                repozytorium_id = user.repozytoria.Find(x => x.dfltInd == "Y").repozytoriumID,
                rokWydania = muzyka.rokWydania,
                typ = TypConst.Muzyka,
            };

            var wydawca = database.Wydawca.Single(x => x.nazwa == muzyka.wydawca);
            if (wydawca != null) position.wydawca = wydawca.id;
            else position.wydawca = wydawcaDao.AddWydawca(muzyka.wydawca);
            if (muzyka.notatka != null) position.notatka = notatkaDao.AddNotatka(muzyka.notatka);
            if (muzyka.ocena != null) position.ocena = muzyka.ocena;
            database.Pozycja.Add(position);
            var music = new Muzyka()
            {
                id = database.Muzyka.Max(x => x.id) + 1,
                iloscPlyt = muzyka.IloscPlyt,
                iloscSciezek = muzyka.IloscSciezek,
                pozycja_id = position.id
            };
            database.Muzyka.Add(music);
            autorDao.ManageAutorsToPosition(muzyka.autorzy, position.id);
            return GetAllMusicForUser(user);
        }

        #region PrivateHelpers
        private List<MuzykaDto> ConvertToDto (List<Muzyka> muzykaList)
        {
            List<MuzykaDto> listaMuzyki = new List<MuzykaDto>();
            foreach(var muzyka in muzykaList)
            {
                List<AutorDto> listaAutorow = new List<AutorDto>();
                 foreach(var autor in muzyka.Pozycja.Autor_Pozycja)
                {
                    listaAutorow.Add(new AutorDto()
                    {
                        idAutora = autor.Autor.id,
                        Imie = autor.Autor.imie,
                        Nazwisko = autor.Autor.nazwisko
                    });
                }
                MuzykaDto _muzyka = new MuzykaDto()
                {
                    idPozycja = muzyka.Pozycja.id,
                    idMuzyka = muzyka.id,
                    IloscPlyt = muzyka.iloscPlyt,
                    IloscSciezek = muzyka.iloscSciezek,
                    udostepnioneDla = muzyka.Pozycja.udostepnioneDla,
                    tytul = muzyka.Pozycja.tytul,
                    typ = muzyka.Pozycja.Typ1.nazwa,
                    rokWydania = muzyka.Pozycja.rokWydania,
                    repositoryID = muzyka.Pozycja.repozytorium_id,
                    wydawca = muzyka.Pozycja.Wydawca1.nazwa,
                    autorzy = listaAutorow
                };
                if(muzyka.Pozycja.Notatka1 != null)
                {
                    _muzyka.notatka = muzyka.Pozycja.Notatka1.tresc;
                }
                if(muzyka.Pozycja.Ocena1 != null)
                {
                    _muzyka.ocena = muzyka.Pozycja.Ocena1.ocena1;
                }
                listaMuzyki.Add(_muzyka);
            }
            return listaMuzyki;
        }
        private bool VerifyMusic(Muzyka muzyka, List<RepozytoriumDto> repo)
        {
            var repository = repo.Find(x => x.repozytoriumID == muzyka.Pozycja.repozytorium_id);
            if (repository != null) return true;
            else return false;
        }
        #endregion
    }
}