using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Component
{
    public class DoctorLapMappings
    {
        public int? DoctorLapMappingID { get; set; }
        public int? LabID { get; set; }
        public int? DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string LabName { get; set; }        
    }
}
