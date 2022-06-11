using LabGuru.BAL.Enums;
using LabGuru.BAL.Repo;
using LabGuru.DAL;
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
    public class UserController : ControllerBase
    {
        private readonly IAuthentication authentication;
        private readonly IDoctor doctor;
        private readonly ILaboratory laboratory;

        public UserController(IAuthentication authentication, IDoctor doctor, ILaboratory laboratory)
        {
            this.authentication = authentication;
            this.doctor = doctor;
            this.laboratory = laboratory;
        }
        [HttpGet]
        public IActionResult Profile()
        {
            ResponceMessages responceMessages = new ResponceMessages();
            try
            {
                var UserIdentity = (ClaimsIdentity)User.Identity;
                var Loginuser = authentication.GetLogin(UserIdentity.Name);
                switch (Loginuser.RoleID)
                {
                    case 1:
                        var Doctor = doctor.GetDoctorDetails(Loginuser.ReferanceID);
                        return Ok(Doctor);
                    case 2:
                        var Lab = laboratory.GetLaboratory(Loginuser.ReferanceID);
                        return Ok(Lab);
                    default:
                        responceMessages = new ResponceMessages()
                        {
                            isSuccess = false,
                            Message = "User Not Found"
                        };
                        return NotFound(responceMessages);
                }
            }
            catch (Exception exp)
            {
                responceMessages = new ResponceMessages()
                {
                    isSuccess = false,
                    Message = exp.Message
                };
                return BadRequest(responceMessages);
            }
        }
    }
}
