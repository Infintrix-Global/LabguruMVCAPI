using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class VM_Labratory
    {
        public int id { get; set; }
        public string LabName { get; set; }
        public string LabAddress { get; set; }
        public bool isDefault { get; set; }

    }
}
