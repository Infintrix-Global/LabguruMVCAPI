using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IDoctorStatusSetting
    {
        int UpdateOrderStatus(DoctorStatusSetting doctorStatus);
        int AddOrderStatus(DoctorStatusSetting doctorStatus);
        bool isExistsOrderStatus(int DoctorID, int LaboratoryID, int StatusID);
        List<DoctorStatusSetting> GetDoctorStatusSettings(int DoctorID, int LaboratoryID);
    }
}
