using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderProcessMaster
    {
        List<ProcessMaster> GetOrderProcessMasters();
        ProcessMaster GetOrderProcessMaster(int id);
        int CreateOrderProcessMasters(ProcessMaster orderProcessMaster);
    }
}
