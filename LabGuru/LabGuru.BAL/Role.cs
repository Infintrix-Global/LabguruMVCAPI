using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class Role
    {
        public Role()
        {
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
