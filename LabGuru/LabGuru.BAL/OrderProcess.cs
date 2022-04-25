using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class OrderProcess
    {
        [Key]
        public int id { get; set; }
        public int OrderID { get; set; }
        public int ProcessMasterID { get; set; }

        [ForeignKey("OrderID")]
        public OrderDetails orderDetails { get; set; }

        [ForeignKey("ProcessMasterID")]
        public OrderProcessMaster orderProcess { get; set; }
        
    }
}
