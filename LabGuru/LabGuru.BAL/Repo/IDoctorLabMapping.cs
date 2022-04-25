using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IDoctorLabMapping
    {
        int AddClinicLab(DoctorLabMapping doctorLabMapping);
        bool isExistsLab(int DoctorID, int LabID);
        List<DoctorLabMapping> Laboratorys(int DoctorID);
        int SetDefaultLab(int DoctorID, int LabID);
    }
}
