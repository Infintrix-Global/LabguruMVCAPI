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
        public int StatusID { get; set; }
    }
}
