using LabGuru.BAL.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IOrderManage
    {
        int CreateOrder(OrderDetails orderDetails);
        int CreateOrderProduct(ProductOrder productOrder);
        int SetCurrentStatus(int OrderID, int StatusID);
        List<OrderDetails> GetOrderDetails(int UserID);
        OrderDetails GetOrderDetail(int OrderID);
        List<ProductOrder> GetProductOrders(int OrderID);

        List<OrderListWithProduct> GetOrdersForDoctor(int DoctorID);
        List<OrderListWithProduct> GetOrdersForLab(int LabID);
        int CreateOrderImpresions(List<OrderImpression> orderImpressions);
        int AcceptOrder(int OrderID);
        int OrderProcessCompleted(string Username, int OrderID, string Remarks);
        int NotAcceptOrder(int OrderID);

        List<OrderListWithProduct> GetOrdersForEmployee(string userName, string userRole);
        int SavedoctorOrderPreferredProcesses(List<DoctorOrderPreferredProcess> doctorOrderPreferreds);
    }
}
