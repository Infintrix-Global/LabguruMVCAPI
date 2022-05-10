using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class SubProcessEmployee
    {
        [Key]
        public int SubProcessEmployeeID { get; set; }

        // Foreign key   
        [Display(Name = "SubProcessID")]
        public virtual int SubProcessID { get; set; }

        [ForeignKey("SubProcessID")]
        public virtual SubProcessMaster SubProcessMasters { get; set; }

        // Foreign key   
        [Display(Name = "LabEmployeeID")]
        public virtual int LabEmployeeID { get; set; }

        [ForeignKey("LabEmployeeID")]
        public virtual LabEmployee LabEmployees { get; set; }

        public bool IsActive { get; set; }

    }
}
