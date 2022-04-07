using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class Product
    {
		[Key]
		public int ProductID { get; set; }
		public int ProductTypeID { get; set; }
		public int ProductMaterialID { get; set; }
		public int ProductSizeID { get; set; }
		public int ProductShadeID { get; set; }
		[MaxLength(50)]
		public string ProductName { get; set; }
		public int ProductCode { get; set; }
		public string ProductImagePath { get; set; }
		public decimal Price { get; set; }
		public decimal CGST { get; set; }
		public decimal SGST { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		[MaxLength(50)]
		public string CreatorIP { get; set; }
		[MaxLength(50)]
		public string UpdatorIP { get; set; }
	}
}
