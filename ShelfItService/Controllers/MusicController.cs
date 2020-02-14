using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelfItService.Repositories;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Music")]
    public class MusicController : Controller
    {
        List<MuzykaDto> listaMuzyki;
        MusicRepository repository;
        public MusicController()
        {
            repository = new MusicRepository();
            listaMuzyki = repository.muzyka;
        }
        [HttpGet()]
        public IActionResult GetAllMusic()
        {
            return Ok(listaMuzyki);
        }
        [HttpGet("{id}")]
        public IActionResult GetMusic(int id)
        {
            var musicToReturn = listaMuzyki.FirstOrDefault(m => m.idMuzyka == id);
            if(musicToReturn == null)
            {
                return NotFound();
            }
            return Ok(musicToReturn);
        }
        [HttpGet("{name}")]
        public IActionResult GetMusic(string name)
        {
            var musicToReturn = listaMuzyki.FirstOrDefault(m => m.tytul.Contains(name));
            if (musicToReturn == null)
            {
                return NotFound();
            }
            return Ok(musicToReturn);
        }
    }
}
