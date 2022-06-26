using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace LabGuru.BAL
{
    public class OrderDetailsByEmployeeProcess
    {
		[Key]
		public int EmployeeOrderProcessID { get; set; }		
		[Required]
		public int OrderID { get; set; }
		[Required]
		public int? EmployeeID { get; set; }
		[Required]
		public int OrderProcessStatus { get; set; }
		[MaxLength(150)]
        public string Remarks { get; set; }

    }
}
