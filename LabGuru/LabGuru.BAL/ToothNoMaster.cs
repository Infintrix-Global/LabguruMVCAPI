using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace LabGuru.BAL
{

   public class ToothNoMaster
    {
        [Key]
        public int toothID { get; set; }
        [Required,MaxLength(50)]
        public string toothNo { get; set; }
    }
}
