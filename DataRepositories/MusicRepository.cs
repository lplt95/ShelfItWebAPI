﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace DataRepositories
{
    public class MusicRepository
    {
        public static List<MuzykaDto> muzyka = new List<MuzykaDto>()
        {
            new MuzykaDto()
            {
                idMuzyka = 1,
                idPozycja = 4,
                repositoryID = 1,
                IloscPlyt = 2,
                IloscSciezek = 30,
                notatka = "Jakaś kocia muzyka! :(",
                ocena = 2,
                rokWydania = 2019,
                typ = TypConst.typMuzyka,
                tytul = "Kocie Rytmy vol. 1",
                wydawca = "Cats Entertainment",
                 autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 4, Imie = "Kot", Nazwisko = "Nieznany"}
                }
            },
            new MuzykaDto()
            {
                idMuzyka = 2,
                idPozycja = 5,
                repositoryID = 2,
                IloscPlyt = 1,
                IloscSciezek = 15,
                notatka = "Ahhh... Mozart!",
                ocena = 5,
                rokWydania = 1790,
                typ = TypConst.typMuzyka,
                tytul = "Klasycy rocka - Mozart",
                wydawca = "W. Mozart Music Deutschland",
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 5, Imie = "Mozart", Nazwisko = "JakiśTam"}
                }
            },
            new MuzykaDto()
            {
                idMuzyka = 3,
                idPozycja = 6,
                repositoryID = 3,
                IloscPlyt = 1,
                IloscSciezek = 10,
                notatka = "Niemiecki metal, fuj.",
                ocena = 1,
                rokWydania = 2019,
                typ = TypConst.typMuzyka,
                tytul = "Deutschland",
                wydawca = "Sony Music Poland",
                autorzy = new List<AutorDto>()
                {
                    new AutorDto(){ idAutora = 6, Imie = "Rammstein", Nazwisko = ""}
                }
            }
        };
        public bool VerifyMusic(MuzykaDto muzyka, List<RepozytoriumDto> repo)
        {
            var repository = repo.Find(x => x.repozytoriumID == muzyka.repositoryID);
            if (repository != null) return true;
            else return false;
        }
    }
}
