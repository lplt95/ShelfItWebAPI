using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelfItService.DataRepositories;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Book")]
    public class BookController : Controller
    {
        List<KsiazkaDto> listaKsiazek;
        BookRepository repository;
        public BookController()
        {
            repository = new BookRepository();
            listaKsiazek = repository.ksiazki;
        }
        [HttpGet()]
        public IActionResult GetAllUsersBook(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var user = UserRepository.userzy.Find(x => x.userID == userID);
            var listToReturn = new List<KsiazkaDto>();
            if(user.sessionID == sessionID)
            {
                foreach(var repo in user.repozytoria)
                {
                    var list = listaKsiazek.FindAll(x => x.repositoryID == repo.repozytoriumID);
                    listToReturn.AddRange(list);
                }
                return Ok(listToReturn);
            }
            else return BadRequest("SessionID is not valid for user");
        }
        [HttpGet("Book")]
        public IActionResult GetBook(int? id, int? userID)
        {
            if (id == null || userID == null) return BadRequest("Values cannot be null!");
            var userRepo = UserRepository.userzy.Find(x => x.userID == userID).repozytoria;
            var bookToReturn = listaKsiazek.FirstOrDefault(k => k.idKsiazka == id);
            if(bookToReturn == null)
            {
                return NotFound();
            }
            if(!repository.VerifyBook(bookToReturn, userRepo))
            {
                return BadRequest("You don't have permission to access this resource");
            }
            return Ok(bookToReturn);
        }
        //[HttpGet("{name}")]
        public IActionResult GetBook(string name)
        {
            var bookToReturn = listaKsiazek.FirstOrDefault(k => k.tytul.Contains(name));
            if (bookToReturn == null)
            {
                return NotFound();
            }
            return Ok(bookToReturn);
        }
        //[HttpGet("Author/{id}")]
        public IActionResult GetBookByAuthor(int id)
        {
            //var booksToReturn =
            return Unauthorized();
        }
    }
}
