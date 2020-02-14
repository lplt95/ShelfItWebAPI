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
            if (sessionID == null || userID == null) return BadRequest();
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
        //[HttpGet("{id}")]
        public IActionResult GetFilm(int id)
        {
            var filmToReturn = listaFilmow.FirstOrDefault(f => f.idFilm == id);
            if (filmToReturn == null)
            {
                return NotFound();
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
