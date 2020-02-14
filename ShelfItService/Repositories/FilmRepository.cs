﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace ShelfItService.Repositories
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
                DlugoscTrwania = 150,
                notatka = "Film taki sobie.",
                ocena = 2,
                rokWydania = 2019,
                typ = TypConst.typFilm,
                tytul = "Justice League",
                wydawca = "Sony"
            });
            filmy.Add(new FilmDto()
            {
                idFilm = 2, 
                idPozycja = 8, 
                DlugoscTrwania = 180,
                notatka = "Fajne",
                ocena = 4,
                rokWydania = 2020,
                typ = TypConst.typFilm,
                tytul = "Piękna i Bestia",
                wydawca = "Disney"
            });
            filmy.Add(new FilmDto()
            {
                idFilm = 3,
                idPozycja = 9, 
                DlugoscTrwania = 90,
                notatka = "",
                ocena = 3,
                rokWydania = 2010,
                typ = TypConst.typFilm,
                tytul = "TO",
                wydawca = "Sony"
            });
        }
    }
}
