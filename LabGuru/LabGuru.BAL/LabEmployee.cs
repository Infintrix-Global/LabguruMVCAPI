using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class LabEmployee
    {
        [Key]
        public int LabEmployeeID { get; set; }

        [ForeignKey("Laboratory")]
        public int ID { get; set; }

        public int RoleID { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string UserName { get; set; }

    }
}
