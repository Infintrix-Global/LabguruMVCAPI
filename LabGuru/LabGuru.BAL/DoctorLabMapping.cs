using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class DoctorLabMapping
    {
        [Key]
        public int id { get; set; }
        public int DoctorID { get; set; }
        public int LabID { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
        [ForeignKey("DoctorID")]
        public DoctorDetails doctorDetails { get; set; }

        [ForeignKey("LabID")]
        public Laboratory laboratory { get; set; }
        public bool isDefault { get; set; } = false;
    }
}
