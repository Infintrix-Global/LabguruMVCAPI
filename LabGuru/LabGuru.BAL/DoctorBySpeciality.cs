using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class DoctorBySpeciality
    {
        [Key]
        public int DoctorBySpecialityID { get; set; }
        [Required]
        public int DoctorID { get; set; }
        [Required]
        public int SpecialityID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(50)]
        public string ModifedBy { get; set; }
    }
}
