using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class Laboratory
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string LabName { get; set; }
        [MaxLength(50)]
        public string LabAddress { get; set; }

    }
}
