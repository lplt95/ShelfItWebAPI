﻿using System;
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
    public class UserController : DefaultController
    {
        UserDao userDao;
        public UserController()
        {
            userDao = new UserDao();
        }
        [HttpPost("Register")]
        public IActionResult RegisterNewUser([FromBody] UserDto user)
        {
            var result = userDao.RegisterUser(user);
            if (result == true) return Ok();
            else return BadRequest("Ops! Something went wrong. User wasn't registered.");
        }
        [HttpGet("Confirm")]
        public IActionResult ConfirmRegistration(string id)
        {
            string message = null;
            var result = userDao.ConfirmRegistration(id, out message);
            if (!result) return BadRequest(message);
            else return Ok(message);
        }
        /*[HttpGet("UsersToConfirm")]
        public IActionResult ShowUsersToConfirm()
        {
            return Ok(confirmRepo);
        }*/
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePass newPass)
        {
            if (newPass == null) return NullValues();
            string message = null;
            var result = userDao.ChangePassword(newPass, out message);
            if (!result) return BadRequest(message);
            return Ok(message);
        }
        [HttpGet("InviteUser")]
        public IActionResult InviteNewUser(string email)
        {
            if (email == null) return NullValues();
            string message = null;
            var result = userDao.InviteNewUser(email, out message);
            if (!result) return BadRequest(message);
            return Ok(message);
        }
        [HttpPost("RemoveChangedPass")]
        public IActionResult RemoveChangedPass(string id)
        {
            string message = null;
            var result = userDao.RemoveChangedPass(id, out message);
            if (result == true) return Ok(message);
            else return BadRequest(message);
        }
    }
}