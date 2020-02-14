using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShelfItService.Repositories;
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
        public IActionResult GetAllFilms()
        {
            return Ok(listaFilmow);
        }
        [HttpGet("{id}")]
        public IActionResult GetFilm(int id)
        {
            var filmToReturn = listaFilmow.FirstOrDefault(f => f.idFilm == id);
            if (filmToReturn == null)
            {
                return NotFound();
            }
            return Ok(filmToReturn);
        }
        [HttpGet("{name}")]
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
