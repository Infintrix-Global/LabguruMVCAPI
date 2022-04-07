using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderProcessMaster
    {
        List<OrderProcessMaster> GetOrderProcessMasters();
        OrderProcessMaster GetOrderProcessMaster(int id);
    }
}
