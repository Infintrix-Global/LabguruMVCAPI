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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratory laboratory;
        private readonly IAuthentication authentication;
        private readonly IDoctorLabMapping labMapping;
        private readonly ResponceMessages responceMessages;

        public LaboratoryController(ILaboratory laboratory, 
            IAuthentication authentication,
            IDoctorLabMapping labMapping, ResponceMessages responceMessages)
        {
            this.laboratory = laboratory;
            this.authentication = authentication;
            this.labMapping = labMapping;
            this.responceMessages = responceMessages;
        }

        [HttpGet]
        public IActionResult GetLaboratory()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var LoginUser = authentication.GetLogin(claimsIdentity.Name);
            if (LoginUser.RoleID == 1)
            {
                var result = labMapping.Laboratorys(LoginUser.UserID);
                List<VM_Labratory> VM_Labratorys = new List<VM_Labratory>();
                foreach (var res in result)
                {
                    VM_Labratorys.Add(new VM_Labratory()
                    {
                        id = res.laboratory.id,
                        LabName = res.laboratory.LabName,
                        LabAddress = res.laboratory.LabAddress,
                        isDefault = res.isDefault
                    });
                }


                return Ok(VM_Labratorys);
            }
            else
            {
                var result = laboratory.GetLaboratories();
                return Ok(result);
            }
        }


        [HttpGet]
        public IActionResult GetLaboratoryByProductID(int productTypeID)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var LoginUser = authentication.GetLogin(claimsIdentity.Name);
            if (LoginUser.RoleID == 1)
            {
                var reslabResult = laboratory.GetLaboratoryByProductID(productTypeID, LoginUser.ReferanceID);

                List<VM_Labratory> VM_Labratorys = new List<VM_Labratory>();
                foreach (var res in reslabResult)
                {
                    VM_Labratorys.Add(new VM_Labratory()
                    {
                        id = res.laboratory.id,
                        LabName = res.laboratory.LabName,
                        LabAddress = res.laboratory.LabAddress,
                        isDefault = res.isDefault
                    });
                }
                return Ok(VM_Labratorys);
            }
            else
            {
                var result = laboratory.GetLaboratories();
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult CreateLaboratoryUser(Laboratory lab)
        {
            var result = laboratory.CreateLaboratoryUsers(lab);
            return result > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));

        }

        [HttpPost]
        public IActionResult CreateLabEmployee(LabEmployee labEmployee)
        {
            var result = laboratory.CreateLabEmployees(labEmployee);
            return result > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));

        }

        //Admin send LabID=0
        [HttpGet]
        public IActionResult GetLabEmployee(int LabID)
        {
            var result = laboratory.GetLabEmployees(LabID);
            return Ok(result);

        }
    }
}
