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
        UserDao userDao;
        public DefaultController()
        {
            userDao = new UserDao();
        }
        [HttpGet]
        public IActionResult CheckStatus()
        {
            //return Ok("You are running ShelfItService");
            return Ok();
        }
        public UserDto VerifyUserSessionID(string sessionID, int? userID)
        {
            UserDto user = userDao.GetUserByUserID(userID, sessionID);
            if (user != null) return user;
            else return null;
        }
        public IActionResult NullValues()
        {
            return BadRequest("Values cannot be null!");
        }
        public IActionResult InvalidSessionID()
        {
            return BadRequest("Session ID is not valid for user!");
        }
    }
}
