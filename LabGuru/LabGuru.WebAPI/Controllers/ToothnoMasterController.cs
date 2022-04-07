using LabGuru.BAL.Repo;
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
    [Authorize]
    public class ToothnoMasterController : ControllerBase
    {
        private readonly IToothnoMasters toothnoMasters;

        public ToothnoMasterController(IToothnoMasters toothnoMasters)
        {
            this.toothnoMasters = toothnoMasters;
        }

        public IActionResult GetToothnomasterList()
        {
            var result = toothnoMasters.GetToothNoMasters();
            return Ok(result);
        }
    }
}
