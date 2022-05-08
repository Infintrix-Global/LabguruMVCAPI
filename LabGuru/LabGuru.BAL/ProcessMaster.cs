using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class ProcessMaster
    {

        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        public string ProcessName { get; set; }

    }
}
