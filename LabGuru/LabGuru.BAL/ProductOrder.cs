using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class ProductOrder
    {
		[Key]
		public int ProductOrderID { get; set; }
		public int OrderID { get; set; }
		public int UserID { get; set; }
		public int ProductTypeID { get; set; }
		public int ProductMaterialID { get; set; }
		public int ProductShadeID { get; set; }
		public string ToothSelection { get; set; }
		public int Quantity { get; set; }
		public decimal PricePerUnit { get; set; }
		public decimal CGST { get; set; }
		public decimal SGST { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		[MaxLength(50)]
		public string CreatorIP { get; set; }
		[MaxLength(50)]
		public string UpdatorIP { get; set; }
		public string Field1 { get; set; }
		public string Field2 { get; set; }
		public string Field3 { get; set; }
		public string Field4 { get; set; }
		[ForeignKey("OrderID")]
        public OrderDetails orderDetails { get; set; }
		[ForeignKey("UserID")]
        public Login login { get; set; }
		[ForeignKey("ProductTypeID")]
		public ProductType productType { get; set; }
		[ForeignKey("ProductMaterialID")]
		public ProductMaterial productMaterial { get; set; }
		[ForeignKey("ProductShadeID")]
		public ProductShade productShade { get; set; }
	}
}
