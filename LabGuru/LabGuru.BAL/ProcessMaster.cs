using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class ProcessMaster
    {

        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        public string ProcessName { get; set; }

        public int? ProductID { get; set; }

        [ForeignKey("ProductID")]
        public ProductType productType { get; set; }

        //[Required]
        public int SortOrder { get; set; }

        //[Required]
        public bool IsActive { get; set; }
    }
}
