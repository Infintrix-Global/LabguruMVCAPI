using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderManage
    {
        int CreateOrder(OrderDetails orderDetails);
        int CreateOrderProduct(ProductOrder productOrder);
        List<OrderDetails> GetOrderDetails(int UserID);
        OrderDetails GetOrderDetail(int OrderID);
        List<ProductOrder> GetProductOrders(int OrderID);

    }
}
