using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusMaster orderStatus;
        private readonly ResponceMessages responceMessages;
        private readonly IAuthentication authentication;

        public OrderStatusController(IOrderStatusMaster orderStatus, ResponceMessages responceMessages,
            IAuthentication authentication)
        {
            this.orderStatus = orderStatus;
            this.responceMessages = responceMessages;
            this.authentication = authentication;
        }

        [HttpPost]
        public IActionResult CreateStatusMaster(OrderStatusMaster statusMaster)
        {
            var UserIdentity = (ClaimsIdentity)User.Identity;
            var Loginuser = authentication.GetLogin(UserIdentity.Name);
            if(Loginuser.RoleID != 2)
            {
                return Ok(responceMessages.Failed("Invalid User Access"));
            }

            statusMaster.LaboratoryID = Loginuser.ReferanceID;
            if (orderStatus.isStatusExists(statusMaster.LaboratoryID, statusMaster.StatusText))
            {
                return Ok(responceMessages.Failed("Already Exists"));
            }

            orderStatus.CreateOrderStatus(statusMaster);
            return Ok(responceMessages.Success("Successfully Created"));
        }

        [HttpGet]
        public IActionResult GetStatusMaster()
        {
            var UserIdentity = (ClaimsIdentity)User.Identity;
            var Loginuser = authentication.GetLogin(UserIdentity.Name);
            
            var result = orderStatus.GetOrderStatusMasters(Loginuser.ReferanceID);
            return Ok(result);
        }
    }
}
