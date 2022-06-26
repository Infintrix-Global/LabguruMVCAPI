using LabGuru.BAL.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface ILabAssignment
    {
        int AssignmentToLab(LabAssignment labAssignment);

        //List<ProcessEmployeeDetail> GetProccessEmployeeDetails(int LabID);

        //int GetProceesCountForEmployee(int LabEmployeeID);

        //int AssignOrderToEmployee(LabAssignment labAssignment);
    }
}
