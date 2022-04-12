using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class OrderStatus
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required,MaxLength(20)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string Remarks { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [ForeignKey("OrderID")]
        public OrderDetails orderDetails { get; set; }
    }
}
