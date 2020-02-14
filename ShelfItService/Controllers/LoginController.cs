﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelfItService.Repositories;
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
            listaUserow = repository.userzy;
        }
        [HttpGet()]
        public IActionResult LoginUser(string userName, string userPassword)
        {
            if(repository.CheckPassword(userName, userPassword))
            {
                UserDto user = listaUserow.Find(x => x.login == userName);
                user.GenerateID();
                return Ok(user.sessionID);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
