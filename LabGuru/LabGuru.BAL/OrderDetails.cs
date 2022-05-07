using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
   public class OrderDetails
    {
        public OrderDetails()
        {
			ProductOrders = new HashSet<ProductOrder>();
		}
		[Key]
		public int OrderID { get; set; }
		[MaxLength(50)]
		public string OrderNumber { get; set; }
		public int UserID { get; set; }
		[MaxLength(50)]
		public string PatientName { get; set; }
		[MaxLength(50)]
		public string PatientGender { get; set; }
		public int? PatientAge { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		[MaxLength(50)]
		public string CreatorIP { get; set; }
		[MaxLength(50)]
		public string UpdatorIP { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public int? ClinicID { get; set; }
        public int? LaboratiryID { get; set; }
        public int ProcessID { get; set; }
		public int CurrentOrderStatusID { get; set; }
		public bool? isAccepted { get; set; }
        [ForeignKey("UserID")]
		public Login loginuser { get; set; }
		[ForeignKey("ClinicID")]
		public DoctorClinic doctorClinic { get; set; }
		[ForeignKey("LaboratiryID")]
		public Laboratory laboratory { get; set; }
		[ForeignKey("ProcessID")]
		public OrderProcessMaster orderProcessMaster { get; set; }
		[ForeignKey("CurrentOrderStatusID")]
		public OrderStatusMaster OrderStatusMast { get; set; }
	}
}
