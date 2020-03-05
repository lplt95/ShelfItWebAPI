using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Film")]
    public class FilmController : Controller
    {
        FilmDao filmDao;
        UserDao userDao;
        public FilmController()
        {
            filmDao = new FilmDao();
            userDao = new UserDao();
        }
        [HttpGet()]
        public IActionResult GetAllUserFilms(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var user = userDao.GetUserByUserID(userID, sessionID);
            if (user == null) return BadRequest("Session ID is not valid for user!");
            var listToReturn = filmDao.GetAllFilmsForUser(user);
            return Ok(listToReturn);
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
        [HttpPost("PostFilm")]
        public IActionResult AddBookToRepository(string sessionID, int? userID, [FromBody] FilmDto film)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var listToReturn = new List<FilmDto>();
            var user = UserRepository.userzy.Find(x => x.userID == userID);
            if (user.sessionID == sessionID)
            {
                if (film == null || film.tytul == null)
                {
                    return BadRequest("Values cannot be null!");
                }
                film.idPozycja = Repository.maxPosID++;
                film.idFilm = listaFilmow.Max(x => x.idFilm);
                film.repositoryID = user.repozytoria.Find(x => x.dfltInd == "Y").repozytoriumID;
                film.typ = TypConst.typKsiazka;
                listaFilmow.Add(film);
                foreach (var repo in user.repozytoria)
                {
                    var list = listaFilmow.FindAll(x => x.repositoryID == repo.repozytoriumID);
                    listToReturn.AddRange(list);
                }
                return Ok(listToReturn);
            }
            else return BadRequest("SessionID is not valid for user");
        }
    }
}
