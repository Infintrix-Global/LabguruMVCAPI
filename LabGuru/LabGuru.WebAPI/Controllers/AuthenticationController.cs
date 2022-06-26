using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication authentication;
        private readonly JwtAuthenticationManager jwtAuthentication;
        private readonly ResponceMessages responceMessages;        

        public AuthenticationController(IAuthentication authentication, JwtAuthenticationManager jwtAuthentication, ResponceMessages responceMessages)
        {
            this.authentication = authentication;
            this.jwtAuthentication = jwtAuthentication;
            this.responceMessages = responceMessages;
        }
        [HttpPost]
        public IActionResult Login(vm_UserLogin userLogin)
        {
            ResponceMessages responceMessages;
            var isValidUser = authentication.Authenticate(userLogin.Username, userLogin.Password);
            if (isValidUser)
            {
                var userDetail = authentication.GetLogin(userLogin.Username);
                var LoginUserToken = jwtAuthentication.GetToken(userLogin.Username, userDetail);
                responceMessages = new ResponceMessages()
                {
                    Data = LoginUserToken,
                    isSuccess = true,
                    Message = "Successfully Login"
                };
                return Ok(responceMessages);
            }
            else
            {
                responceMessages = new ResponceMessages()
                {
                    Data = null,
                    isSuccess = false,
                    Message = "Invalid Credantial Provider"
                };
                return Unauthorized(responceMessages);
            }

        }
        [HttpGet]
        [Authorize]
        public IActionResult authguard()
        {
            return Ok(responceMessages.Success("Valid Login"));
        }

        [HttpGet]
        public IActionResult GetPassword(string password)
        {
            password = BCrypt.Net.BCrypt.HashPassword(password);
            return Ok(password);
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                var result = authentication.GetRoles();
                
                return Ok(result.Where(w=>w.RoleID != 1 && w.RoleID != 2 && w.RoleID != 3));
            }
            catch (Exception exp)
            {
                responceMessages.Failed(exp.Message);
                return BadRequest(responceMessages);
            }
        }

    }
}
