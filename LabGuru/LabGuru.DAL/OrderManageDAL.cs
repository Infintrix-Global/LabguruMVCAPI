using LabGuru.BAL;
using LabGuru.BAL.Component;
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
        private readonly IDoctorStatusSetting doctorStatus;

        public OrderManageDAL(LabGuruDbContext dbContext, IDoctorStatusSetting doctorStatus)
        {
            this.dbContext = dbContext;
            this.doctorStatus = doctorStatus;
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

        public List<OrderListWithProduct> GetOrdersForDoctor(int DoctorID)
        {
            var result = from ord in dbContext.OrderDetails
                         join ordProd in dbContext.ProductOrders on ord.OrderID equals ordProd.OrderID
                         join Prod in dbContext.ProductTypes on ordProd.ProductTypeID equals Prod.ProductTypeID
                         where ord.UserID == DoctorID
                         select new OrderListWithProduct
                         {
                             OrderID = ord.OrderID,
                             OrderNumber = ord.OrderNumber,
                             CreatedDate = ord.CreatedDate,
                             PatientName = ord.PatientName,
                             PatientAge = ord.PatientAge,
                             PatientGender = ord.PatientGender,
                             ProductName = Prod.ProductTypeName,
                             ProductImage = Prod.ProductTypeImagePath,
                             ProductTypeID = Prod.ProductTypeID,
                             TotalPrice = ord.TotalPrice,
                             DeliveryDate = ordProd.DeliveryDate,
                             CurrentOrderStatus = (dbContext.OrderStatusMasters.Where(w => w.id == ord.CurrentOrderStatusID).Select(s => s.StatusText).FirstOrDefault())
                         };
            return result.ToList();
        }

        public List<OrderListWithProduct> GetOrdersForLab(int LabID)
        {

            var result = from ord in dbContext.OrderDetails
                         join ordProd in dbContext.ProductOrders on ord.OrderID equals ordProd.OrderID
                         join Prod in dbContext.ProductTypes on ordProd.ProductTypeID equals Prod.ProductTypeID
                         where ord.LaboratiryID == LabID
                         orderby ord.CreatedDate descending
                         select new OrderListWithProduct
                         {
                             OrderID = ord.OrderID,
                             OrderNumber = ord.OrderNumber,
                             CreatedDate = ord.CreatedDate,
                             PatientName = ord.PatientName,
                             PatientAge = ord.PatientAge,
                             PatientGender = ord.PatientGender,
                             ProductName = Prod.ProductTypeName,
                             ProductImage = Prod.ProductTypeImagePath,
                             ProductTypeID = Prod.ProductTypeID,
                             TotalPrice = ord.TotalPrice,
                             DeliveryDate = ordProd.DeliveryDate,
                             isAccepted = ord.isAccepted,
                             
                             StatusList = (from DSS in dbContext.DoctorStatusSettings
                                           join Status in dbContext.OrderStatusMasters on DSS.StatusMasterID equals Status.id
                                           where Status.LaboratoryID == LabID &&
                                                     DSS.DoctorID == ord.UserID && DSS.Include
                                           select new DoctorStatusSetting
                                           {
                                               id = DSS.id,
                                               Include = DSS.Include,
                                               LaboratoryID = DSS.LaboratoryID,
                                               ShowToDoctor = DSS.ShowToDoctor,
                                               StatusMaster = Status
                                           }).OrderBy(o => o.StatusMaster.DispalyOrder).ToList()
                         };
            return result.ToList();
        }

        public int SetCurrentStatus(int OrderID, int StatusID)
        {
            var orderD = dbContext.OrderDetails.Where(w => w.OrderID == OrderID).FirstOrDefault();
            if (orderD != null)
            {
                orderD.CurrentOrderStatusID = StatusID;
                return dbContext.SaveChanges();
            }
            return 0;
        }

        public int AcceptOrder(int OrderID)
        {

            var orderD = dbContext.OrderDetails.Where(w => w.OrderID == OrderID).FirstOrDefault();
            if (orderD != null)
            {
                orderD.isAccepted = true;
                return dbContext.SaveChanges();
            }
            return 0;
        }

        public int NotAcceptOrder(int OrderID)
        {
            var orderD = dbContext.OrderDetails.Where(w => w.OrderID == OrderID).FirstOrDefault();
            if (orderD != null)
            {
                orderD.isAccepted = false;
                return dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
