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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratory laboratory;
        private readonly IAuthentication authentication;

        public LaboratoryController(ILaboratory laboratory, IAuthentication authentication)
        {
            this.laboratory = laboratory;
            this.authentication = authentication;
        }

        [HttpGet]
        public IActionResult GetLaboratory()
        {
            var result = laboratory.GetLaboratories();
            return Ok(result);
        }
    }
}
