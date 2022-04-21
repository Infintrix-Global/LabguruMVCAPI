using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class OrderManageDAL : IOrderManage
    {
        private readonly LabGuruDbContext dbContext;

        public OrderManageDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int CreateOrder(OrderDetails orderDetails)
        {
            dbContext.OrderDetails.Add(orderDetails);
            return dbContext.SaveChanges();
        }
        public int CreateOrderProduct(ProductOrder productOrder)
        {
            dbContext.ProductOrders.Add(productOrder);
            return dbContext.SaveChanges();
        }

        public OrderDetails GetOrderDetail(int OrderID)
        {
            return dbContext.OrderDetails.Where(w => w.OrderID == OrderID).FirstOrDefault();
        }

        public List<ProductOrder> GetProductOrders(int OrderID)
        {
            var Result = from OP in dbContext.ProductOrders
                         join PT in dbContext.ProductTypes on OP.ProductTypeID equals PT.ProductTypeID
                         join PS in dbContext.ProductShades on OP.ProductShadeID equals PS.ProductShadeID
                         join PM in dbContext.ProductMaterials on OP.ProductMaterialID equals PM.ProductMaterialID
                         where OP.OrderID == OrderID
                         select new ProductOrder
                         {
                             ProductOrderID = OP.ProductOrderID,
                             Quantity = OP.Quantity,
                             PricePerUnit = OP.PricePerUnit,
                             TotalPrice = OP.TotalPrice,
                             CreatedDate = OP.CreatedDate,
                             CreatorIP = OP.CreatorIP,
                             Field1 = OP.Field1,
                             Field2 = OP.Field2,
                             Field3 = OP.Field3,
                             Field4 = OP.Field4,
                             ToothSelection = OP.ToothSelection,
                             productType = PT,
                             productMaterial = PM,
                             productShade = PS
                         };

            return Result.ToList();
        }

        public List<OrderDetails> GetOrderDetails(int UserID)
        {

            return dbContext.OrderDetails.Where(w => w.UserID == UserID).OrderByDescending(O => O.CreatedDate).ToList();
        }

        public List<OrderDetails> GetOrdersForDoctor(int DoctorID)
        {
            var result = from ord in dbContext.OrderDetails
                         join ordProd in dbContext.ProductOrders on ord.OrderID equals ordProd.OrderID
                         join Prod in dbContext.ProductTypes on ordProd.ProductTypeID equals Prod.ProductTypeID
                         where ord.UserID == DoctorID
                         select new OrderDetails
                         {
                             OrderID = ord.OrderID,
                            
                         };
            return result.ToList();
        }

        public List<OrderDetails> GetOrdersForLab(int LabID)
        {
            throw new NotImplementedException();
        }
    }
}
