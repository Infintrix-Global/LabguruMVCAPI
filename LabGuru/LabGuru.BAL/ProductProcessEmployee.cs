using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class ProductProcessEmployee
    {
        [Key]
        public int ProductProcessEmployeeID { get; set; }

        // Foreign key   
        [Display(Name = "ProductTypeID")]
        public virtual int ProductTypeID { get; set; }

        [ForeignKey("ProductTypeID")]
        public virtual ProductType ProductTypes { get; set; }

        // Foreign key   
        [Display(Name = "ProcessID")]
        public virtual int ProcessID { get; set; }

        [ForeignKey("ProcessID")]
        public virtual ProcessMaster ProcessMasters { get; set; }

        // Foreign key   
        [Display(Name = "LabID")]
        public virtual int LabID { get; set; }

        [ForeignKey("LabID")]
        public virtual Laboratory Laboratories { get; set; }

        [Display(Name = "LabEmployeeID")]
        public virtual int LabEmployeeID { get; set; }

        [ForeignKey("LabEmployee")]
        public virtual LabEmployee LabEmployees { get; set; }
                
        [Required]
        public bool IsActive { get; set; }
    }
}
