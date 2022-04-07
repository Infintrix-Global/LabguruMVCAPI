using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class DoctorClinic
    {
        [Key]
        public int id { get; set; }
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public Login loginuser { get; set; }

        [MaxLength(50)]
        public string ClinicName { get; set; }
        [MaxLength(20)]
        public string ClinicMobileNo { get; set; }
        public string ClinicAddress { get; set; }
        [MaxLength(10)]
        public string ClinicPincode { get; set; }
        [MaxLength(50)]
        public string ClinicDist { get; set; }
        [MaxLength(50)]
        public string ClinicState { get; set; }
    }
}
