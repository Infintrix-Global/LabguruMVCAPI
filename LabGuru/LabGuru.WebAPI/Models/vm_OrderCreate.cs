using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class vm_OrderCreate
    {
        public string OrderNo { get; set; }
        public int UserID { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public int? PatientAge { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreatorIP { get; set; }
        public int ProductTypeID { get; set; }
        public int? ProductMaterialID { get; set; }
        public int? ProductShadID { get; set; }
        public string ToothNo { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }

        public int ClinicID { get; set; }
        public int ProcessID { get; set; }
        public int LaboratiryID { get; set; }
    }
}
