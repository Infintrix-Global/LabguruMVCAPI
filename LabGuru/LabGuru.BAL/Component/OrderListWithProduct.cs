using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Component
{
	public class OrderListWithProduct
	{
		public int OrderID { get; set; }
		public string OrderNumber { get; set; }

		public string PatientName { get; set; }
		public string PatientGender { get; set; }
		public int? PatientAge { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		
		public string ProductName { get; set; }
		public int ProductTypeID { get; set; }
        public string ProductImage { get; set; }
		public string CurrentOrderStatus { get; set; }
		public int CurrentOrderStatusID { get; set; }
		public DateTime DeliveryDate { get; set; }
        public bool? isAccepted { get; set; }

        public List<DoctorStatusSetting> StatusList { get; set; }
		public List<OrderStatusMaster> StatusMasters { get; set; }
        public DoctorClinic doctorClinic { get; set; }
        public DoctorDetails doctorDetails { get; set; }

    }
}

