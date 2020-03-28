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
    public class FilmController : DefaultController
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
            if (sessionID == null || userID == null) return NullValues();
            var user = userDao.GetUserByUserID(userID, sessionID);
            if (user == null) return InvalidSessionID();
            var listToReturn = filmDao.GetAllFilmsForUser(user);
            return Ok(listToReturn);
        }
        [HttpGet("Film")]
        public IActionResult GetFilm(int? id, int? userID, string sessionID)
        {
            if (id == null || userID == null || sessionID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var movieToReturn = filmDao.GetMovie(user, id);
            if (movieToReturn == null) return BadRequest("Movie not found or you cannot see this record.");
            return Ok(movieToReturn);
        }
        [HttpPost("PostFilm")]
        public IActionResult AddFilmToRepository(string sessionID, int? userID, [FromBody] FilmDto film)
        {
            if (sessionID == null || userID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var movieToReturn = filmDao.AddFilmToDatabase(film, user);
            return Ok(movieToReturn);
        }
        /*[HttpDelete("DeleteFilm")]
        public IActionResult DeleteBookFromRepository(string sessionID, int? userID, int? filmID)
        {
            if (sessionID == null || userID == null || filmID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var bookToReturn = filmDao.(user, filmID);
            return Ok(bookToReturn);
        }*/
    }
}
