using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Component
{
    public class LaboratoryEmployee
    {
        public int? LabEmployeeID { get; set; }
        public int? LabID { get; set; }
        public int? RoleID { get; set; }
        public string EmployeeName { get; set; }
        public string LabName { get; set; }
        public string RoleName { get; set; }
    }
}
