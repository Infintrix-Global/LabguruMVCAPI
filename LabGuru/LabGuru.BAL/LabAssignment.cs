using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class LabAssignment
    {
        [Key]
        public int id { get; set; }

        public int OrderID { get; set; }
        public int ParentLabID { get; set; }
        public int ChildLabID { get; set; }

        [ForeignKey("OrderID")]
        public OrderDetails orderDetails { get; set; }

        [ForeignKey("ParentLabID")]
        public Laboratory ParentLab { get; set; }
        [ForeignKey("ChildLabID")]
        public Laboratory ChildLab { get; set; }
        //public DateTime AssignDate { get; set; } = DateTime.Now;
        //public DateTime ExpectedDeliveryDate { get; set; }

    }
}
