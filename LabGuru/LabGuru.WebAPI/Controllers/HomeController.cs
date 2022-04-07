using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult AllowAll()
        {
            return Ok("All User");
        }
        [HttpGet]
        [Authorize]
        public IActionResult ValidUser()
        {
            return Ok("Valid User");
        }
    }
}
