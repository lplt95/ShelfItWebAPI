using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataTransfer;


namespace ShelfItService.Controllers
{
    [Route("ShelfIt/Login")]
    public class LoginController : Controller
    {
        UserDao userDao;
        public LoginController()
        {
            userDao = new UserDao();
        }
        [HttpGet("In")]
        public IActionResult LoginUser(string userName, string userPassword)
        {
            if (userName == null || userPassword == null) return BadRequest("Values cannot be null!");
            var user = userDao.LoginUser(userName, userPassword);
            if (user == null) return BadRequest("Wrong login or password!");
            return Ok(user.userID + ", " + user.sessionID);
        }
        [HttpGet("Out")]
        public IActionResult LogoutUser(int? userID, string sessionID)
        {
            if (userID == null || sessionID == null) return BadRequest("Values cannot be null!");
            var isSuccess = userDao.LogoutUser(userID, sessionID);
            if (!isSuccess) return BadRequest("Failed to logout user! Data was wrong!");
            return Ok();
        }
    }
}
