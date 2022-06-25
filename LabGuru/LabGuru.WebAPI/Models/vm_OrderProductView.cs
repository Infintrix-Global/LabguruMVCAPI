using LabGuru.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class vm_OrderProductView
    {
        public int productOrderID { get; set; }
        public string toothSelection { get; set; }
        public int quantity { get; set; }
        public decimal pricePerUnit { get; set; }
        public DateTime createdDate { get; set; }
        public string creatorIP { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string field4 { get; set; }
        public string productTypeName { get; set; }
        public string productTypeImagePath { get; set; }
        public string productMatrialName { get; set; }
        public string productShadeName { get; set; }
        public DateTime DeliveryDate { get; set; }
        
    }
}
