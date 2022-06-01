using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class vm_ProductType_Create
    {
     
        public string ProductTypeName { get; set; }
        public bool isImpressionMindatory { get; set; } = false;
        public List<IFormFile> formFiles { get; set; }
    
    }
}
