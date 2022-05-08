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

        [ForeignKey("ProductTypeID")]
        public int ProductID { get; set; }

        [ForeignKey("Laboratory")]
        public int ID { get; set; }

        [ForeignKey("LabEmployee")]
        public int LabEmployeeID { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
