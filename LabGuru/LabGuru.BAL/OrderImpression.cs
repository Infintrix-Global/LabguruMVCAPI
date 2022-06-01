using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class OrderImpression
    {
        [Key]
        public int OrderImpressionID { get; set; }
        public string FilePath { get; set; }
        public int OrderID { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [ForeignKey("OrderID")]
        public OrderDetails orderDetails { get; set; }
    }
}
