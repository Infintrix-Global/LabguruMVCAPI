using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class vm_OrderView
    {
        public vm_OrderView()
        {
            OrderProducts = new List<vm_OrderProductView>();
        }
        public int orderID { get; set; }
        public string orderNumber { get; set; }
        public string patientName { get; set; }
        public string patientGender { get; set; }
        public int? patientAge { get; set; }
        public decimal totalPrice { get; set; }
        public DateTime createdDate { get; set; }
        public string creatorIP { get; set; }
        public List<vm_OrderProductView> OrderProducts { get; set; }
    }

}
