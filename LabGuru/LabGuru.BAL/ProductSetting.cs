using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class ProductSetting
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ProductID { get; set; }
        
        [Required]
        public int DeliveryDays { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        [ForeignKey("ProductID")]
        public ProductType productType { get; set; }
    }
}
