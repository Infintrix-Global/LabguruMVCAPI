using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class vm_LoginedUser
    {
        public string Token { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
    }
}
