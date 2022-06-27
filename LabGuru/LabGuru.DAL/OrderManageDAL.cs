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
        private readonly IDoctor doctor;

        public OrderManageDAL(LabGuruDbContext dbContext, IDoctorStatusSetting doctorStatus, IDoctor doctor)
        {
            this.dbContext = dbContext;
            this.doctorStatus = doctorStatus;
            this.doctor = doctor;
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
                         join PS in dbContext.ProductShades on OP.ProductShadeID equals PS.ProductShadeID into PSlist
                            from PS in PSlist.DefaultIfEmpty()
                         join PM in dbContext.ProductMaterials on OP.ProductMaterialID equals PM.ProductMaterialID into PMlist 
                            from PM in PMlist.DefaultIfEmpty()
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
                             productShade = PS,
                             
                         };
            var res = Result.ToList();
            return res;
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
                             CurrentOrderStatusID = ord.CurrentOrderStatusID,
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
                                           }).OrderBy(o => o.StatusMaster.DispalyOrder).ToList(),
                             doctorClinic = ord.doctorClinic,
                         };
            return result.ToList();
        }

        public List<OrderListWithProduct> GetOrdersForEmployee(string userName, string userRole)
        {

            var result = from ord in dbContext.OrderDetails
                         join ordProd in dbContext.ProductOrders on ord.OrderID equals ordProd.OrderID
                         join Prod in dbContext.ProductTypes on ordProd.ProductTypeID equals Prod.ProductTypeID
                         join odem in dbContext.OrderDetailsByEmployeeProcess on ordProd.OrderID equals odem.OrderID
                         join lg in dbContext.Logins on odem.EmployeeID equals lg.ReferanceID 
                         join r in dbContext.Roles on lg.RoleID equals r.RoleID
                         where lg.UserName == userName && r.RoleName == userRole
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
                             CurrentOrderStatusID = ord.CurrentOrderStatusID,
                             StatusList = (from DSS in dbContext.DoctorStatusSettings
                                           join Status in dbContext.OrderStatusMasters on DSS.StatusMasterID equals Status.id
                                           where Status.LaboratoryID == ord.LaboratiryID &&
                                                     DSS.DoctorID == ord.UserID && DSS.Include
                                           select new DoctorStatusSetting
                                           {
                                               id = DSS.id,
                                               Include = DSS.Include,
                                               LaboratoryID = DSS.LaboratoryID,
                                               ShowToDoctor = DSS.ShowToDoctor,
                                               StatusMaster = Status
                                           }).OrderBy(o => o.StatusMaster.DispalyOrder).ToList(),
                             doctorClinic = ord.doctorClinic,
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

            if (dbContext.OrderDetailsByEmployeeProcess.Where(o => o.OrderID == OrderID).Count() > 0)
                return -2;

            var orderD = dbContext.OrderDetails.Where(w => w.OrderID == OrderID).FirstOrDefault();
            if (orderD != null)
            {
                orderD.isAccepted = true;

                //since order is accepeted changing status to "Order Confirmed"
                var result = dbContext.OrderDetails.Where(w => w.OrderID == OrderID).FirstOrDefault();

                var labOrderStatus = dbContext.OrderStatusMasters.Where(osm => osm.LaboratoryID == result.LaboratiryID && osm.StatusText == "Order Confirmed").FirstOrDefault();

                result.CurrentOrderStatusID = labOrderStatus.id;
                //Assigning the order to an employee based on the process selected

                //Thereafter assigning order to Process Manager
                var employeeProcess = from ppe in dbContext.ProductProcessEmployees
                                      join od in dbContext.OrderDetails on ppe.LabID equals od.LaboratiryID
                                      join p in dbContext.ProcessMasters on od.ProcessID equals p.id
                                      where od.OrderID == OrderID
                                      select new OrderProcessEmployeeList
                                      {
                                          OrderID = od.OrderID,
                                          LabID = od.LaboratiryID,
                                          ProcessID = od.ProcessID,
                                          LabEmployeeID = ppe.LabEmployeeID
                                      };

                var empList = employeeProcess.Distinct().ToList();

                if (empList.Count() > 0)
                {
                    OrderDetailsByEmployeeProcess obep = new OrderDetailsByEmployeeProcess();
                    obep.OrderID = OrderID;
                    obep.EmployeeID = empList.First().LabEmployeeID;
                    obep.OrderProcessStatus = 1;
                    obep.Remarks = "Order assigned to Process Manager.";

                    dbContext.OrderDetailsByEmployeeProcess.Add(obep);
                    return dbContext.SaveChanges();
                }
                else
                    return -1;
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

        public int CreateOrderImpresions(List<OrderImpression> orderImpressions)
        {
            dbContext.OrderImpressions.AddRange(orderImpressions);
            return dbContext.SaveChanges();
        }
    }
}
