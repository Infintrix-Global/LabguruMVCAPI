using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class SubProcessMaster
    {
        [Key]
        public int SubProcessID { get; set; }

        // Foreign key   
        [Display(Name = "ProcessID")]
        public virtual int ProcessID { get; set; }

        [ForeignKey("ProcessID")]
        public virtual ProcessMaster ProcessMasters { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubProcessName { get; set; }

        public bool IsActive { get; set; }

    }
}
