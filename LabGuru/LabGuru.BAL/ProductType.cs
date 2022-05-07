using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class ProductType
    {
        [Key]
        public int ProductTypeID { get; set; }
        [Required, MaxLength(60)]
        public string ProductTypeName { get; set; }
        public string ProductTypeImagePath { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        [Required, MaxLength(15)]
        public string CreatorIP { get; set; }
        [Required, MaxLength(15)]
        public string UpdatorIP { get; set; }

        public bool isImpressionMindatory { get; set; } = false;

    }
}
