using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class VM_Labratory
    {
        public int id { get; set; }
        public int LabID { get; set; }
        public string Name { get; set; }
        public string labAddress { get; set; }
        public bool isDefault { get; set; }

    }
}
