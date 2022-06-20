using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderProcessMaster
    {
        List<ProcessMaster> GetOrderProcessMasters();
        List<ProcessMaster> GetOrderProcessMasters(int ProductID);
        ProcessMaster GetOrderProcessMaster(int id);

        List<ProcessMaster> GetOrderProcessByLabId(int labId);

        int CreateOrderProcessMasters(ProcessMaster orderProcessMaster);

        int CreateProductProcessEmployeeMapping(ProductProcessEmployee productProcessEmployee);

        List<ProductProcessEmployee> GetProductProcessEmployee();
   
    }
}
