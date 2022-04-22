using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IDoctorLabMapping
    {
        int AddClinicLab(DoctorLabMapping doctorLabMapping);
        bool isExistsLab(int ClinicID, int LabID);
        List<DoctorLabMapping> Laboratorys(int ClinicID);
        int SetDefaultLab(int clinicID, int LabID);
    }
}
