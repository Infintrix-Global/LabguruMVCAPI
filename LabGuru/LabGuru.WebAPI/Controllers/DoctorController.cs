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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorClinic doctorClinic;
        private readonly IAuthentication authentication;
        private readonly IDoctorLabMapping labMapping;
        private readonly ResponceMessages responceMessages;
        private readonly IDoctorStatusSetting _doctorStatusSetting;
        private readonly IOrderStatusMaster _orderStatus;
        private readonly IDoctor _doctor;

        public DoctorController(IDoctorClinic doctorClinic, IAuthentication authentication,
            IDoctorLabMapping labMapping,
            ResponceMessages responceMessages,
            IDoctorStatusSetting _doctorStatusSetting,
            IOrderStatusMaster _orderStatus,
            IDoctor doctor)
        {
            this.doctorClinic = doctorClinic;
            this.authentication = authentication;
            this.labMapping = labMapping;
            this.responceMessages = responceMessages;
            this._doctorStatusSetting = _doctorStatusSetting;
            this._orderStatus = _orderStatus;
            this._doctor = doctor;
        }
        
        [HttpGet]
        public IActionResult GetDoctorList()
        {
           var result = _doctor.GetDoctorDetails();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetClinics()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            int LoginUserID = authentication.GetLogin(claimsIdentity.Name).UserID;
            var result = doctorClinic.GetDoctorClinics(LoginUserID);
            List<VM_DoctorClinic> listDC = new List<VM_DoctorClinic>();
            foreach (var res in result)
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
                    isDefault = res.isDefault,
                });
            }
            return Ok(listDC);
        }


        [HttpPost]
        public IActionResult MapLab(DoctorLabMapping CliniclabMapping)
        {
            try
            {
                if (!labMapping.isExistsLab(CliniclabMapping.DoctorID, CliniclabMapping.LabID))
                {

                    var result = labMapping.AddClinicLab(CliniclabMapping);
                    if (result > 0)
                        return Ok(responceMessages.Success("Successfully Map With Lab"));
                    else
                        return BadRequest(responceMessages.Failed("Something Went Wrong"));
                }
                else
                {
                    return Ok(responceMessages.Failed("Already Exists"));
                }

            }
            catch (Exception exp)
            {
                return BadRequest(responceMessages.Failed(exp.Message));
            }
        }

        [HttpGet]
        public IActionResult GetMapedLaboratorys()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            int LoginUserID = authentication.GetLogin(claimsIdentity.Name).UserID;
            var result = labMapping.Laboratorys(LoginUserID);
            List<VM_Labratory> VM_Labratorys = new List<VM_Labratory>();
            foreach(var res in result)
            {
                VM_Labratorys.Add(new VM_Labratory()
                {
                    id = res.id,
                    LabName = res.laboratory.LabName,
                    LabAddress = res.laboratory.LabAddress,
                    isDefault = res.isDefault
                });
            }
            return Ok(VM_Labratorys);
        }
        [HttpPost]
        public IActionResult UpdateDoctorOrderStatus(List<DoctorStatusSetting> statusSettings)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var LoginUser = authentication.GetLogin(claimsIdentity.Name);
                if (LoginUser.ReferanceType != BAL.Enums.LoginReference.Laboratory)
                    return Ok(responceMessages.Success("Invalid User Access"));
                int newRecord = 0;
                int updatedRecord = 0;
                foreach (var statusSetting in statusSettings)
                {
                    statusSetting.LaboratoryID = LoginUser.ReferanceID;
                    if (_doctorStatusSetting.isExistsOrderStatus(statusSetting.DoctorID, statusSetting.LaboratoryID, statusSetting.StatusMasterID))
                    {
                        updatedRecord += _doctorStatusSetting.UpdateOrderStatus(statusSetting);
                    }
                    else
                    {
                        newRecord += _doctorStatusSetting.AddOrderStatus(statusSetting);
                    }
                }
                return Ok(responceMessages.Success("Successfullly", new { NewRecord = newRecord, UpdatedRecord = updatedRecord }));
            }
            catch (Exception exp)
            {
                return Ok(responceMessages.Failed(exp.Message));
            }
        }

        [HttpGet]
        public IActionResult GetDoctorOrderStatus(int DoctorClinicID)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var LoginUser = authentication.GetLogin(claimsIdentity.Name).ReferanceID;
                var result = _doctorStatusSetting.GetDoctorStatusSettings(DoctorClinicID, LoginUser);
               
                return Ok(result);
            }
            catch (Exception exp)
            {
                return Ok(responceMessages.Failed(exp.Message));
            }
        }

    }
}
