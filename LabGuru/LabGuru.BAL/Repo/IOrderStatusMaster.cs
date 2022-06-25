using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderStatusMaster
    {
        int CreateOrderStatus(OrderStatusMaster orderStatusMaster);
        bool isStatusExists(int LabID, string StatusText);
        List<OrderStatusMaster> GetOrderStatusMasters(int LabID);
        List<DoctorStatusSetting> GetDoctorStatus(int labID, int DoctorID);
    }
}
