using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class VM_DoctorClinic
    {
        public int id { get; set; }
        public string ClinicName { get; set; }
        public string ClinicMobileNo { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicPincode { get; set; }
        public string ClinicDist { get; set; }
        public string ClinicState { get; set; }
    }
}
