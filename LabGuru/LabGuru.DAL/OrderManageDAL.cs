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

            var currentEmployeeID = (from log in dbContext.Logins
                                    join le in dbContext.LabEmployees on log.ReferanceID equals le.LabEmployeeID
                                    join r in dbContext.Roles on log.RoleID equals r.RoleID
                                    where log.UserName == userName && r.RoleName == userRole
                                    select new
                                    {
                                        le.LabEmployeeID
                                    }).FirstOrDefault();

            var result = from ord in dbContext.OrderDetails
                         join ordProd in dbContext.ProductOrders on ord.OrderID equals ordProd.OrderID
                         join Prod in dbContext.ProductTypes on ordProd.ProductTypeID equals Prod.ProductTypeID
                         join odem in dbContext.OrderDetailsByEmployeeProcess on ordProd.OrderID equals odem.OrderID
                         join lg in dbContext.Logins on odem.EmployeeID equals lg.ReferanceID
                         join r in dbContext.Roles on lg.RoleID equals r.RoleID
                         where odem.OrderProcessStatus==1 && odem.EmployeeID == currentEmployeeID.LabEmployeeID
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

                var ProcessID = (from ddo in dbContext.DoctorOrderPreferredProcesses
                                 join pros in dbContext.ProcessMasters on ddo.ProcessID equals pros.id
                                 where ddo.OrderID == OrderID && ddo.IsCompleted == false
                                 orderby pros.SortOrder
                                 select new
                                 {
                                     ddo.ProcessID
                                 }).FirstOrDefault();

                var employeeProcess = from ppe in dbContext.ProductProcessEmployees
                                      join od in dbContext.OrderDetails on ppe.LabID equals od.LaboratiryID
                                      //join p in dbContext.ProcessMasters on od.ProcessID equals p.id
                                      join dopp in dbContext.DoctorOrderPreferredProcesses on od.OrderID equals dopp.OrderID
                                      where od.OrderID == OrderID
                                      select new OrderProcessEmployeeList
                                      {
                                          OrderID = od.OrderID,
                                          LabID = od.LaboratiryID,
                                          ProcessID = ProcessID.ProcessID,
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

        public int SavedoctorOrderPreferredProcesses(List<DoctorOrderPreferredProcess> doctorOrderPreferreds)
        {
            dbContext.DoctorOrderPreferredProcesses.AddRange(doctorOrderPreferreds);
            return dbContext.SaveChanges();
        }

        public int OrderProcessCompleted(string Username, int OrderID, string Remarks)
        {

            var currentEmployeeID = (from log in dbContext.Logins
                                     join le in dbContext.LabEmployees on log.ReferanceID equals le.LabEmployeeID
                                     join r in dbContext.Roles on log.RoleID equals r.RoleID
                                     where log.UserName == Username && r.RoleID==4
                                     select new
                                     {
                                         le.LabEmployeeID
                                     }).FirstOrDefault();

            //Updating old process if Process Manager has completed the process
            var result = (from od in dbContext.OrderDetails
                          join odep in dbContext.OrderDetailsByEmployeeProcess on od.OrderID equals odep.OrderID
                          join ppe in dbContext.ProductProcessEmployees on od.ProcessID equals ppe.ProcessID
                          join lg in dbContext.Logins on ppe.LabEmployeeID equals lg.ReferanceID
                          where odep.EmployeeID == currentEmployeeID.LabEmployeeID && odep.OrderID == OrderID && odep.OrderProcessStatus == 1
                          select new
                          {
                              odep.EmployeeOrderProcessID,
                              odep.OrderID,
                              odep.EmployeeID,
                              ppe.ProcessID
                          }).ToList().FirstOrDefault();

            OrderDetailsByEmployeeProcess odep2 = new OrderDetailsByEmployeeProcess();
            odep2.EmployeeOrderProcessID = result.EmployeeOrderProcessID;
            odep2.Remarks = Remarks;
            odep2.OrderProcessStatus = 2;
            odep2.EmployeeID = result.EmployeeID;
            odep2.OrderID = result.OrderID;
            dbContext.OrderDetailsByEmployeeProcess.Update(odep2);
            dbContext.SaveChanges();
            


            //Now updating the DoctorOrderPreferredProcesses table to mark the process completed

            var resultDoctorSelectedProcess = (from t in dbContext.DoctorOrderPreferredProcesses
                                              where t.OrderID == result.OrderID && t.ProcessID==result.ProcessID && t.IsCompleted==false
                                              select t).FirstOrDefault();



            resultDoctorSelectedProcess.IsCompleted = true;
            resultDoctorSelectedProcess.Remarks = "Assigning to order to next process manager in the queue if any.";
            dbContext.SaveChanges();

            var ProcessID = (from ddo in dbContext.DoctorOrderPreferredProcesses
                             join pros in dbContext.ProcessMasters on ddo.ProcessID equals pros.id
                             where ddo.OrderID == OrderID && ddo.IsCompleted == false
                             orderby pros.SortOrder
                             select new
                             {
                                 ddo.ProcessID
                             }).FirstOrDefault();

            var count = (from ddo in dbContext.DoctorOrderPreferredProcesses
                         join pros in dbContext.ProcessMasters on ddo.ProcessID equals pros.id
                         where ddo.OrderID == OrderID && ddo.IsCompleted == false
                         orderby pros.SortOrder
                         select new
                         {
                             ddo.ProcessID
                         }).Count();

            if (count == 0)
            {
                var resultOrderDetails = (from t in dbContext.OrderDetails
                                          where t.OrderID == result.OrderID 
                                          select t).FirstOrDefault();

                var resultOrderStatusMaster = (from t in dbContext.OrderDetails
                                               join l in dbContext.OrderStatusMasters on t.LaboratiryID equals l.LaboratoryID
                                               where t.ProcessID == result.ProcessID && l.StatusText == "Completed"
                                               select l).FirstOrDefault();

                resultOrderDetails.CurrentOrderStatusID = resultOrderStatusMaster.id;
                dbContext.SaveChanges();

                return -2;
            }

            if (ProcessID.ProcessID > 0)
            {

                var nextProcessEmployeeID = (from dopp in dbContext.DoctorOrderPreferredProcesses
                                             join ppe in dbContext.ProductProcessEmployees on dopp.ProcessID equals ppe.ProcessID
                                             where dopp.OrderID == OrderID && dopp.IsCompleted == false
                                             select new
                                             {
                                                 ppe.LabEmployeeID
                                             }).FirstOrDefault();


                var employeeProcess = (from ppe in dbContext.ProductProcessEmployees
                                      join od in dbContext.OrderDetails on ppe.LabID equals od.LaboratiryID
                                      //join p in dbContext.ProcessMasters on od.ProcessID equals p.id
                                      join dopp in dbContext.DoctorOrderPreferredProcesses on od.OrderID equals dopp.OrderID
                                      where dopp.OrderID == OrderID && dopp.IsCompleted == false
                                      orderby dopp.DoctorOrderPeferredProcessID
                                      select new OrderProcessEmployeeList
                                      {
                                          OrderID = od.OrderID,
                                          LabID = od.LaboratiryID,
                                          ProcessID = ProcessID.ProcessID,
                                          LabEmployeeID = nextProcessEmployeeID.LabEmployeeID
                                      }).FirstOrDefault();

                var empList = employeeProcess;

                if (employeeProcess != null)
                {
                    OrderDetailsByEmployeeProcess obep1 = new OrderDetailsByEmployeeProcess();
                    obep1.OrderID = OrderID;
                    obep1.EmployeeID = empList.LabEmployeeID;
                    obep1.OrderProcessStatus = 1;
                    obep1.Remarks = "Order assigned to Next Process Manager in queue.";

                    dbContext.OrderDetailsByEmployeeProcess.Add(obep1);
                    dbContext.SaveChanges();
                    return 1;
                }
                else
                    return -1;
            }
            return 0;
        }
    }
}
