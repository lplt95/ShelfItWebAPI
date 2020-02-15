using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelfItService.DataRepositories;
using DataTransfer;


namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Login")]
    public class LoginController : Controller
    {
        List<UserDto> listaUserow;
        UserRepository repository;
        public LoginController()
        {
            repository = new UserRepository();
            listaUserow = UserRepository.userzy;
        }
        [HttpGet("In")]
        public IActionResult LoginUser(string userName, string userPassword)
        {
            if(repository.CheckPassword(userName, userPassword))
            {
                UserDto user = listaUserow.Find(x => x.login == userName);
                user.LogoutUser();
                user.GenerateID();
                return Ok(user.userID + ", " + user.sessionID);
            }
            else return BadRequest("Wrong login or password!");
        }
        [HttpGet("Out")]
        public IActionResult LogoutUser(int? userID, string sessionID)
        {
            if (userID == null || sessionID == null) return BadRequest();
            var user = listaUserow.Find(x => x.userID == userID);
            if (user.sessionID == sessionID)
            {
                user.LogoutUser();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
