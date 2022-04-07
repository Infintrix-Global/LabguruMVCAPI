using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
   public class ProductShade
    {
		[Key]
		public int ProductShadeID { get; set; }
		[MaxLength(50)]
		public string ProductShadeName { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		[MaxLength(50)]
		public string CreatorIP { get; set; }
		[MaxLength(50)]
		public string UpdatorIP { get; set; }
	}
}
