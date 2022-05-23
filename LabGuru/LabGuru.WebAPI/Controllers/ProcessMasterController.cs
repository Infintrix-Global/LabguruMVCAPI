using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
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
        private readonly ResponceMessages responceMessages;

        public ProcessMasterController(IOrderProcessMaster orderProcess, IAuthentication authentication, ResponceMessages responceMessages)
        {
            this.orderProcess = orderProcess;
            this.authentication = authentication;
            this.responceMessages = responceMessages;
        }

        [HttpGet]
        public IActionResult GetOrderProcess()
        {
            var result = orderProcess.GetOrderProcessMasters();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetOrderProcessByLabId(int labId)
        {
            var result = orderProcess.GetOrderProcessByLabId(labId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrderProcessMaster(ProcessMaster orderProcessMaster)
        {
            var result = orderProcess.CreateOrderProcessMasters(orderProcessMaster);
            return result > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));

        }

        [HttpPost]
        public IActionResult CreateProcessMapper(ProductProcessEmployee productProcessEmployee)
        {
            var result = orderProcess.CreateProductProcessEmployeeMapping(productProcessEmployee);
            return result > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));

        }

        [HttpGet]
        public IActionResult GetProcessMapper()
        {
            var result = orderProcess.GetProductProcessEmployee();
            return Ok(result);
        }
    }
}
