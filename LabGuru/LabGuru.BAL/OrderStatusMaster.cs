using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class OrderStatusMaster
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int LaboratoryID { get; set; }
        [Required, MaxLength(20)]
        public string StatusText { get; set; }
        public int DispalyOrder { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [ForeignKey("LaboratoryID")]
        public virtual Laboratory laboratory { get; set; }
    }
}
