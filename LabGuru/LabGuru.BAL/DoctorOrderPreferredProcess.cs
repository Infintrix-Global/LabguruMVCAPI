using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class DoctorOrderPreferredProcess
    {
        [Key]
        public int DoctorOrderPeferredProcessID { get; set; }

        public int? OrderID { get; set; }

        [ForeignKey("OrderID")]
        public OrderDetails orderDetails { get; set; }

        public int? ProcessID { get; set; }

        [ForeignKey("ProcessID")]
        public ProcessMaster processMasters { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        public string Remarks { get; set; }
    }
}
