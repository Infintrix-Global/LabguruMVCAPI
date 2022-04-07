using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IDoctor
    {
        DoctorDetails GetDoctorDetails(int DoctorDetailsID);
    }
}
