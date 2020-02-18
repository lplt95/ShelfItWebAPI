﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepositories;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Film")]
    public class FilmController : Controller
    {
        List<FilmDto> listaFilmow;
        FilmRepository repository;
        public FilmController()
        {
            repository = new FilmRepository();
            listaFilmow = FilmRepository.filmy;
        }
        [HttpGet]
        public IActionResult GetAllFilms(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var user = UserRepository.userzy.Find(x => x.userID == userID);
            var listToReturn = new List<FilmDto>();
            if (user.sessionID == sessionID)
            {
                foreach (var repo in user.repozytoria)
                {
                    var list = listaFilmow.FindAll(x => x.repositoryID == repo.repozytoriumID);
                    listToReturn.AddRange(list);
                }
                return Ok(listToReturn);
            }
            else
            {
                return BadRequest("SessionID is not valid for user");
            }
        }
        [HttpGet("Film")]
        public IActionResult GetBook(int? id, int? userID)
        {
            if (id == null || userID == null) return BadRequest("Values cannot be null!");
            var userRepo = UserRepository.userzy.Find(x => x.userID == userID).repozytoria;
            var filmToReturn = listaFilmow.FirstOrDefault(f => f.idFilm == id);
            if (filmToReturn == null)
            {
                return NotFound();
            }
            if (!repository.VerifyFilm(filmToReturn, userRepo))
            {
                return BadRequest("You don't have permission to access this resource");
            }
            return Ok(filmToReturn);
        }
        [HttpPost("Film")]
        public IActionResult AddBookToRepository(string sessionID, int? userID, [FromBody] FilmDto film)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var user = UserRepository.userzy.Find(x => x.userID == userID);
            if (user.sessionID == sessionID)
            {
                if (film == null || film.tytul == null)
                {
                    return BadRequest("Values cannot be null!");
                }
                film.idPozycja = Repository.maxPosID++;
                film.idFilm = listaFilmow.Max(x => x.idFilm);
                film.repositoryID = user.repozytoria.Find(x => x.dfltInd == 'Y').repozytoriumID;
                film.typ = TypConst.typKsiazka;
                listaFilmow.Add(film);
                return Ok();
            }
            else return BadRequest("SessionID is not valid for user");
        }
    }
}
