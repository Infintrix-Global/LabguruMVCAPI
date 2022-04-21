using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class DoctorStatusSetting
    {
        public int id { get; set; }
        public int LaboratoryID { get; set; }
        public int DoctorID { get; set; }
        public int StatusMasterID { get; set; }
        public bool Include { get; set; }
        public bool ShowToDoctor { get; set; }

        [ForeignKey("StatusMasterID")]
        public virtual OrderStatusMaster StatusMaster { get; set; }
        [ForeignKey("LaboratoryID")]
        public virtual Laboratory laboratory { get; set; }
        [ForeignKey("DoctorID")]
        public virtual DoctorDetails doctorDetails { get; set; }
    }
}
