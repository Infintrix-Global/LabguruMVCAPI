using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class DoctorDegree
    {
        [Key]
        public int DegreeID { get; set; }
        [Required, MaxLength(50)]
        public string DegreeName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }

        public int DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public DoctorDetails DoctorDetails { get; set; }
    }
}
