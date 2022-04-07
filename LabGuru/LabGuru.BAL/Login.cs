using LabGuru.BAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class Login
    {
        [Key]
        public int UserID { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string RoleID { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        public LoginReference ReferanceType { get; set; }
        [Required]
        public int ReferanceID { get; set; }
        [Required, MaxLength(50)]
        public string IMEI { get; set; } = "asdasdasd";
    }
}
