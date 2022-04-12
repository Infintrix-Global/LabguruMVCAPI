using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderStatus
    {
        int AddOrderStatus(OrderStatus orderStatus);
        List<OrderStatus> GetOrderStatuses(int OrderID);
    }
}
