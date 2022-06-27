using LabGuru.BAL.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface ILaboratory
    {
        List<Laboratory> GetLaboratories();
        Laboratory GetLaboratory(int id);

        int CreateLaboratoryUsers(Laboratory lab);

        int CreateLabEmployees(LabEmployee labEmployee);

        List<LaboratoryEmployee> GetLabEmployees(int LabID);

        List<DoctorLabMapping> GetLaboratoryByProductID(int productTypeId, int doctorId);

        LabEmployee GetLabEmployee(int UserId, int roleID);


    }
}
