using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface ISubProcess
    {
        int AddSubProcess(SubProcessMaster SubProcess);

        int AddSubProcessEmployee(SubProcessEmployee SubProcessEmployees);

        List<SubProcessMaster> GetAllSubProcess(int LabID);

        List<SubProcessMaster> GetAllSubProcess();

        List<SubProcessEmployee> GetSubProcessEmployee(int LabID);

    }
}
