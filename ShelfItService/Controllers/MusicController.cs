using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelfItService.DataRepositories;
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
        public IActionResult GetAllMusic(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return BadRequest();
            var user = UserRepository.userzy.Find(x => x.userID == userID);
            var listToReturn = new List<MuzykaDto>();
            if (user.sessionID == sessionID)
            {
                foreach (var repo in user.repozytoria)
                {
                    var list = listaMuzyki.FindAll(x => x.repositoryID == repo.repozytoriumID);
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
        public IActionResult GetMusic(int id)
        {
            var musicToReturn = listaMuzyki.FirstOrDefault(m => m.idMuzyka == id);
            if(musicToReturn == null)
            {
                return NotFound();
            }
            return Ok(musicToReturn);
        }
        //[HttpGet("{name}")]
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
