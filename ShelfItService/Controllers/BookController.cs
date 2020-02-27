using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Book")]
    public class BookController : Controller
    {
        BookDao bookDao;
        UserDao userDao;
        public BookController()
        {
            bookDao = new BookDao();
            userDao = new UserDao();
        }
        [HttpGet()]
        public IActionResult GetAllUsersBook(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var user = userDao.GetUserByUserID(userID, sessionID);
            if (user == null) return BadRequest("SessionID is not valid for user!");
            var listToReturn = bookDao.GetAllBooksForUser(user);
            return Ok(listToReturn);
        }
        [HttpGet("Book")]
        public IActionResult GetBook(int? id, int? userID, string sessionID)
        {
            if (id == null || userID == null || sessionID == null) return BadRequest("Values cannot be null!");
            var user = userDao.GetUserByUserID(userID, sessionID);
            if (user == null) return BadRequest("SessionID is not valid for user!");
            var bookToReturn = bookDao.GetBook(user, id);
            if (bookToReturn == null) return BadRequest("Book not found or you cannot see this record.");
            return Ok(bookToReturn);
        }
        [HttpPost("PostBook")]
        public IActionResult AddBookToRepository(string sessionID, int? userID, [FromBody] KsiazkaDto ksiazka)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var user = userDao.GetUserByUserID(userID, sessionID);
            if (user == null) return BadRequest("SessionID is not valid for user!");
            var bookToReturn = bookDao.AddBookToDatabase(ksiazka, user);
            return Ok(bookToReturn);
        }
    }
}
