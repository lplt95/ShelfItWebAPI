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
    public class BookController : DefaultController
    {
        BookDao bookDao;
        public BookController()
        {
            bookDao = new BookDao();
        }
        [HttpGet()]
        public IActionResult GetAllUserBooks(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var listToReturn = bookDao.GetAllBooksForUser(user);
            return Ok(listToReturn);
        }
        [HttpGet("Book")]
        public IActionResult GetBook(int? id, int? userID, string sessionID)
        {
            if (id == null || userID == null || sessionID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var bookToReturn = bookDao.GetBook(user, id);
            if (bookToReturn == null) return BadRequest("Book not found or you cannot see this record.");
            return Ok(bookToReturn);
        }
        [HttpPost("PostBook")]
        public IActionResult AddBookToRepository(string sessionID, int? userID, [FromBody] KsiazkaDto ksiazka)
        {
            if (sessionID == null || userID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var bookToReturn = bookDao.AddBookToDatabase(ksiazka, user);
            return Ok(bookToReturn);
        }
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBookFromRepository(string sessionID, int? userID, int? bookID)
        {
            if (sessionID == null || userID == null || bookID == null) return NullValues();
            var user = VerifyUserSessionID(sessionID, userID);
            if (user == null) return InvalidSessionID();
            var bookToReturn = bookDao.DeleteBookFromDatabase(user, bookID);
            return Ok(bookToReturn);
        }
    }
}
