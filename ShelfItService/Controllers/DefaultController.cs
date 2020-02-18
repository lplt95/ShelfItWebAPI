using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelfItService.Controllers
{
    [Route("ShelfIt")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult CheckStatus()
        {
            //return Ok("You are running ShelfItService");
            return Ok();
        }
    }
}
