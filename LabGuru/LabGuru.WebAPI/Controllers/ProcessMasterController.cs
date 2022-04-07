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
    public class ProcessMasterController : ControllerBase
    {
        private readonly IOrderProcessMaster orderProcess;
        private readonly IAuthentication authentication;

        public ProcessMasterController(IOrderProcessMaster orderProcess, IAuthentication authentication)
        {
            this.orderProcess = orderProcess;
            this.authentication = authentication;
        }

        [HttpGet]
        public IActionResult GetOrderProcess()
        {
            var result = orderProcess.GetOrderProcessMasters();
            return Ok(result);
        }
    }
}
