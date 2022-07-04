using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SubProcessController : ControllerBase
    {
        private readonly ISubProcess subProcess;
        private readonly IAuthentication authentication;
        private readonly ResponceMessages responceMessages;

        public SubProcessController(ISubProcess subProcess, IAuthentication authentication, ResponceMessages responceMessages)
        {
            this.subProcess = subProcess;
            this.authentication = authentication;
            this.responceMessages = responceMessages;
        }

        //[HttpGet]
        //public IActionResult GetOrderProcess()
        //{
        //    var result = orderProcess.GetOrderProcessMasters();
        //    return Ok(result);
        //}

        [HttpPost]
        public IActionResult AddSubProcess(SubProcessMaster subProcessMaster)
        {
            var result = subProcess.AddSubProcess(subProcessMaster);
            return result > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));

        }

        [HttpPost]
        public IActionResult AddSubProcessEmployee(SubProcessEmployee subProcessEmployee)
        {
            var result = subProcess.AddSubProcessEmployee(subProcessEmployee);
            return result > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));

        }

        [HttpGet]
        public IActionResult GetSubProcess()
        {
            var result = subProcess.GetAllSubProcess();
            return Ok(result);
        }
    }
}
