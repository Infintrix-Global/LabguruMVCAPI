using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class vm_OrderStatus
    {
        public int id { get; set; }
        public int OrderID { get; set; }
        public string StatusText { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
