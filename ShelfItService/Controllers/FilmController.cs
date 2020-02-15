using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShelfItService.DataRepositories;
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
            listaFilmow = repository.filmy;
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
        //[HttpGet("{name}")]
        public IActionResult GetFilm(string name)
        {
            var filmToReturn = listaFilmow.FirstOrDefault(f => f.tytul.Contains(name));
            if (filmToReturn == null)
            {
                return NotFound();
            }
            return Ok(filmToReturn);
        }
    }
}
