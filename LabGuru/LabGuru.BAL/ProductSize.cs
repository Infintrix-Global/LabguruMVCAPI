using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class ProductSize
    {
		[Key]
		public int ProductSizeID { get; set; }
		[MaxLength(50)]
		public string ProductSizeName { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		[MaxLength(50)]
		public string CreatorIP { get; set; }
		[MaxLength(50)]
		public string UpdatorIP { get; set; }
	}
}
