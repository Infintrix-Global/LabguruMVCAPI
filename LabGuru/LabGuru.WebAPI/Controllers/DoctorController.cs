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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorClinic doctorClinic;
        private readonly IAuthentication authentication;

        public DoctorController(IDoctorClinic doctorClinic, IAuthentication authentication)
        {
            this.doctorClinic = doctorClinic;
            this.authentication = authentication;
        }
        //[HttpGet]
        //public IActionResult GetAllProductType()
        //{
        //    var productTypes =productType.GetProductTypes();
        //    return Ok(productTypes);
        //}

        [HttpGet]
        public IActionResult GetClinics()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            int LoginUserID = authentication.GetLogin(claimsIdentity.Name).UserID;
            var result = doctorClinic.GetDoctorClinics(LoginUserID);
            List<VM_DoctorClinic> listDC = new List<VM_DoctorClinic>();
            foreach(var res in result)
            {
                listDC.Add(new VM_DoctorClinic()
                {
                    ClinicAddress = res.ClinicAddress,
                    ClinicDist = res.ClinicDist,
                    ClinicMobileNo = res.ClinicMobileNo,
                    ClinicName = res.ClinicName,
                    ClinicPincode = res.ClinicPincode,
                    ClinicState = res.ClinicState,
                    id = res.id,
                });
            }
            return Ok(listDC);
        }

    }
}
