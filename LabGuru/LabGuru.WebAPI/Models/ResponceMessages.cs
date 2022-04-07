using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class ResponceMessages
    {
        public bool isSuccess{ get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
