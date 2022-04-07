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

        public AuthenticationController(IAuthentication authentication, JwtAuthenticationManager jwtAuthentication)
        {
            this.authentication = authentication;
            this.jwtAuthentication = jwtAuthentication;
        }
        [HttpPost]
        public IActionResult Login(vm_UserLogin userLogin)
        {
            ResponceMessages responceMessages;
            var isValidUser = authentication.Authenticat(userLogin.Username, userLogin.Password);
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
        public IActionResult GetPassword(string password)
        {
            password = BCrypt.Net.BCrypt.HashPassword(password);
            return Ok(password);
        }

    }
}
