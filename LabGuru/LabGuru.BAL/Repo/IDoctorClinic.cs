using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IDoctorClinic
    {
        DoctorClinic GetDoctorClinic(int id);
        List<DoctorClinic> GetDoctorClinics(int DoctorID);
        int SetDefaultClinic(int DoctorID, int ClinicID);

        int AddClilin(DoctorClinic doctorClinic);

    }
}
