using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelfItService.Repositories;
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
        public IActionResult GetAllBooks()
        {
            return Ok(listaKsiazek);
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var bookToReturn = listaKsiazek.FirstOrDefault(k => k.idKsiazka == id);
            if(bookToReturn == null)
            {
                return NotFound();
            }
            return Ok(bookToReturn);
        }
        [HttpGet("{name}")]
        public IActionResult GetBook(string name)
        {
            var bookToReturn = listaKsiazek.FirstOrDefault(k => k.tytul.Contains(name));
            if (bookToReturn == null)
            {
                return NotFound();
            }
            return Ok(bookToReturn);
        }
        [HttpGet("Author/{id}")]
        public IActionResult GetBookByAuthor(int id)
        {
            //var booksToReturn =
            return Unauthorized();
        }
    }
}
