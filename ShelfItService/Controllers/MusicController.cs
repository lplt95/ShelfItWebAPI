using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataRepositories;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Music")]
    public class MusicController : Controller
    {
        /*List<MuzykaDto> listaMuzyki;
        MusicRepository repository;
        public MusicController()
        {
            listaMuzyki = MusicRepository.muzyka;
            repository = new MusicRepository();
        }
        [HttpGet()]
        public IActionResult GetAllMusic(string sessionID, int? userID)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
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
        [HttpGet("Music")]
        public IActionResult GetMusic(int? id, int? userID)
        {
            if (id == null || userID == null) return BadRequest("Values cannot be null!");
            var userRepo = UserRepository.userzy.Find(x => x.userID == userID).repozytoria;
            var musicToReturn = listaMuzyki.FirstOrDefault(m => m.idMuzyka == id);
            if (musicToReturn == null)
            {
                return NotFound();
            }
            if (!repository.VerifyMusic(musicToReturn, userRepo))
            {
                return BadRequest("You don't have permission to access this resource");
            }
            return Ok(musicToReturn);
        }
        [HttpPost("PostMusic")]
        public IActionResult AddMusicToRepository(string sessionID, int? userID, [FromBody] MuzykaDto music)
        {
            if (sessionID == null || userID == null) return BadRequest("Values cannot be null!");
            var listToReturn = new List<MuzykaDto>();
            var user = UserRepository.userzy.Find(x => x.userID == userID);
            if (user.sessionID == sessionID)
            {
                if (music == null || music.tytul == null)
                {
                    return BadRequest("Values cannot be null!");
                }
                music.idPozycja = Repository.maxPosID++;
                music.idMuzyka = listaMuzyki.Max(x => x.idMuzyka);
                music.repositoryID = user.repozytoria.Find(x => x.dfltInd == 'Y').repozytoriumID;
                music.typ = TypConst.typKsiazka;
                listaMuzyki.Add(music);
                foreach (var repo in user.repozytoria)
                {
                    var list = listaMuzyki.FindAll(x => x.repositoryID == repo.repozytoriumID);
                    listToReturn.AddRange(list);
                }
                return Ok(listToReturn);
            }
            else return BadRequest("SessionID is not valid for user");
        }*/
    }
}
