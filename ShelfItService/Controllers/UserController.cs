using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataRepositories;
using DataAccess;
using DataTransfer;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt/User")]
    public class UserController : Controller
    {
        UserRepository repo;
        List<UsersToConfirmDto> confirmRepo;
        List<UserDto> listaUserow;
        EmailProvider emailProvider;
        public UserController()
        {
            repo = new UserRepository();
            confirmRepo = ConfirmRepository.confirmList;
            listaUserow = UserRepository.userzy;
            emailProvider = new EmailProvider();
        }
        [HttpPost("Register")]
        public IActionResult RegisterNewUser([FromBody] UserDto user)
        {
            if (user == null) return BadRequest("Values cannot be null!");
            user.userID = listaUserow.Max(x => x.userID) + 1;
            user.repozytoria = new List<RepozytoriumDto>() { new RepozytoriumDto()
            {
                repozytoriumID = UserRepository.repoMax,
                repoNumber = 1,
                wlascicielID = user.userID,
                dfltInd = 'Y',
                nazwa = "Default"
            } };
            user.IsConfirmed = false;
            user.GenerateID();
            string result = emailProvider.SendRegisterEmail(user, ApiElementsEnum.confirmLink + user.sessionID);
            if (result == "Success!")
            {
                confirmRepo.Add(new UsersToConfirmDto() { generatedLinkHash = user.sessionID, userID = user.userID });
                user.LogoutUser();
                listaUserow.Add(user);
                return Ok(result);
            }
            else return BadRequest("Something went wrong. User wasn't registered.");
        }
        [HttpGet("Confirm")]
        public IActionResult ConfirmRegistration(string id)
        {
            UsersToConfirmDto confUser = confirmRepo.Find(x => x.generatedLinkHash == id);
            if (confUser != null)
            {
                UserDto user = listaUserow.Find(x => x.userID == confUser.userID);
                user.IsConfirmed = true;
                confirmRepo.RemoveAll(x => x.userID == user.userID);
                return Ok("Email is confirmed. You can login into app now.");
            }
            else return BadRequest("Cannot find predicted ID.");
        }
        [HttpGet("UsersToConfirm")]
        public IActionResult ShowUsersToConfirm()
        {
            return Ok(confirmRepo);
        }
    }
}