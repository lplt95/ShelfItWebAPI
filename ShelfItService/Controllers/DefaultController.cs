using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataTransfer;
using System.Threading.Tasks;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt")]
    public class DefaultController : Controller
    {
        /*UserDao userDao;
        BookDao bookDao;
        FilmDao filmDao;
        MusicDao musicDao;
        public DefaultController()
        {
            userDao = new UserDao();
            bookDao = new BookDao();
            filmDao = new FilmDao();
            musicDao = new MusicDao();
        }
        [HttpGet]
        public IActionResult CheckStatus()
        {
            //return Ok("You are running ShelfItService");
            return Ok();
        }*/
        public UserDto VerifyUserSessionID(string sessionID, int? userID)
        {
            //UserDto user = userDao.GetUserByUserID(userID, sessionID);
            //if (user != null) return user;
            return null;
        }
        /*[HttpPost("PostFromMobile")]
        public IActionResult PostPositionsFromMobile([FromBody] List<KsiazkaDto> bookList, [FromBody] List<FilmDto> filmList, [FromBody] List<MuzykaDto> musicList, string sessionID, int? userID)
        {
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            try
            {
                foreach (var book in bookList)
                {
                    bookDao.AddBookToDatabase(book, user);
                }
                foreach (var film in filmList)
                {
                    filmDao.AddFilmToDatabase(film, user);
                }
                foreach (var music in musicList)
                {
                    musicDao.AddMusicToDatabase(music, user);
                }
            }
            catch (Exception e)
            {
                return BadRequest("Fail to save objects!\n" + e.Message);
            }
            return Ok();
        }*/
        protected IActionResult NullValues()
        {
            return BadRequest("Values cannot be null!");
        }
        protected IActionResult InvalidSessionID()
        {
            return BadRequest("Session ID is not valid for user!");
        }
    }
}
