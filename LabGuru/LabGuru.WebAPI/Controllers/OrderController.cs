using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManage orderManage;
        private readonly IAuthentication authentication;
        private readonly IOrderStatus _orderStatus;
        private readonly ResponceMessages responceMessages;
        private readonly IDoctorLabMapping labMapping;
        private readonly IDoctorClinic doctorClinic;
        private readonly IProductSetting productSetting;
        private readonly ILabAssignment labAssignment;
        private readonly IOrderStatusMaster _orderStatusMaster;
        private readonly IDoctor doctorRepo;

        public OrderController(IOrderManage orderManage, IAuthentication authentication, IOrderStatus _orderStatus,
            ResponceMessages responceMessages, IDoctorLabMapping labMapping, IDoctorClinic doctorClinic,
            IProductSetting productSetting, ILabAssignment labAssignment, IDoctorStatusSetting doctorStatusSetting, IOrderStatusMaster _orderStatusMaster, IDoctor doctorRepo)

        {
            this.orderManage = orderManage;
            this.authentication = authentication;
            this._orderStatus = _orderStatus;
            this.responceMessages = responceMessages;
            this.labMapping = labMapping;
            this.doctorClinic = doctorClinic;
            this.productSetting = productSetting;
            this.labAssignment = labAssignment;
            this._orderStatusMaster = _orderStatusMaster;
            this.doctorRepo = doctorRepo;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult CreateOrder([FromForm] vm_OrderCreate orderCreate)
        {
            try
            {
                Random random = new Random();
                int OrderNo = random.Next(1000, 9999);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var LoginUser = authentication.GetLogin(claimsIdentity.Name);

                OrderDetails orderDetails = new OrderDetails()
                {
                    CreatorIP = orderCreate.CreatorIP,
                    OrderNumber = "ORD-" + OrderNo,
                    PatientAge = orderCreate.PatientAge,
                    PatientGender = orderCreate.PatientGender,
                    PatientName = orderCreate.PatientName,
                    TotalPrice = random.Next(1000, 9999),
                    UserID = LoginUser.ReferanceID,
                    ClinicID = orderCreate.ClinicID,
                    ProcessID = 1,
                    LaboratiryID = orderCreate.LaboratiryID,
                    Remarks = orderCreate.Remakrs,
                    CurrentOrderStatusID = _orderStatusMaster.GetOrderStatusMasters((int)orderCreate.LaboratiryID).OrderBy(o=>o.DispalyOrder).Select(s=>s.id).FirstOrDefault()
                };
                
                List<string> ImpressionImageList = new List<string>();
                if (orderCreate.formFiles != null)
                {
                    UploadDocument uploadDocument = new UploadDocument(Request);
                    ImpressionImageList = uploadDocument.UploadImages(orderCreate.formFiles, Models.Enums.DocumentTypes.ImpressionImage);
                }
                

                if (LoginUser.RoleID == 1)
                {
                    if (orderManage.CreateOrder(orderDetails) > 0)
                    {

                        var prodSett = productSetting.GetProductDeliveryDays(orderCreate.ProductTypeID);
                        int DeliveryDate = 0;
                        if (prodSett != null)
                        {
                            DeliveryDate = prodSett.DeliveryDays;
                        }
                        if (!string.IsNullOrEmpty(orderCreate.ProcessID))
                        {
                            List<DoctorOrderPreferredProcess> _doctorOrderPreferredProcesses = new List<DoctorOrderPreferredProcess>();
                            foreach (var processID in orderCreate.ProcessID.Split(","))
                            {
                                _doctorOrderPreferredProcesses.Add(new DoctorOrderPreferredProcess()
                                {
                                    IsCompleted = false,
                                    OrderID = orderDetails.OrderID,
                                    ProcessID = Convert.ToInt32(processID),
                                });
                            }

                            orderManage.SavedoctorOrderPreferredProcesses(_doctorOrderPreferredProcesses);
                        }
                        ProductOrder productOrder = new ProductOrder()
                        {
                            CGST = 0,
                            CreatorIP = orderCreate.CreatorIP,
                            Field1 = orderCreate.Field1,
                            Field2 = orderCreate.Field2,
                            Field3 = orderCreate.Field3,
                            Field4 = orderCreate.Field4,
                            PricePerUnit = 0,
                            ProductMaterialID = orderCreate.ProductMaterialID,
                            OrderID = orderDetails.OrderID,
                            ProductShadeID = orderCreate.ProductShadID,
                            ProductTypeID = orderCreate.ProductTypeID,
                            Quantity = 1,
                            SGST = 0,
                            ToothSelection = orderCreate.ToothNo,
                            TotalPrice = 0,
                            UserID = LoginUser.UserID,
                            DeliveryDate = DateTime.Now.AddDays(DeliveryDate)

                        };
                        if (orderManage.CreateOrderProduct(productOrder) > 0)
                        {
                            if (orderCreate.formFiles != null && orderCreate.formFiles.Count > 0)
                            {
                                
                                List<OrderImpression> orderImpressions = new List<OrderImpression>();
                                foreach (var IML in ImpressionImageList)
                                {
                                    orderImpressions.Add(new OrderImpression()
                                    {
                                        FilePath = IML,
                                        OrderID = orderDetails.OrderID,
                                    });
                                }
                                if (orderImpressions.Count > 0)
                                {
                                    orderManage.CreateOrderImpresions(orderImpressions);
                                }
                            }

                            ResponceMessages responceMessages = new ResponceMessages()
                            {
                                Data = new { orderDetails.OrderNumber, orderDetails.OrderID },
                                isSuccess = true,
                                Message = "Order Placed Successfully"
                            };
                            if (orderCreate.LaboratiryID != null)
                            {
                                int LaboratiryID = (int)orderCreate.LaboratiryID;
                                labMapping.SetDefaultLab(LoginUser.UserID, LaboratiryID);
                            }
                            if (orderCreate.ClinicID != null)
                            {
                                int ClinicID = (int)orderCreate.ClinicID;
                                doctorClinic.SetDefaultClinic(LoginUser.UserID, ClinicID);
                            }

                            return Ok(responceMessages);
                        }
                    }
                    return BadRequest("Something want wrong");
                }

                else
                {
                    return BadRequest("User not allowed to create order.");
                }

            }
            catch (Exception exp)
            {
                return BadRequest(responceMessages.Failed(exp.Message, exp));
            }
        }

        [HttpGet]
        public IActionResult GetOrderList()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var LoginUser = authentication.GetLogin(claimsIdentity.Name);
            if (LoginUser.RoleID == 1)
            {
                var result = orderManage.GetOrdersForDoctor(LoginUser.ReferanceID);
                return Ok(result);
            }
            else
            {
                var result = orderManage.GetOrdersForLab(LoginUser.ReferanceID);
                return Ok(result);
            }
        }
        [HttpGet]
        public IActionResult GetOrderDetail(int orderID)
        {
            var orderDetails = orderManage.GetOrderDetail(orderID);
            var productOrders = orderManage.GetProductOrders(orderID);
            if (orderDetails == null)
            {
                return NotFound("Invalid Order Search");
            }
            List<vm_OrderProductView> _OrderProductViews = new List<vm_OrderProductView>();
            foreach (var pd in productOrders)
            {
                _OrderProductViews.Add(new vm_OrderProductView()
                {
                    createdDate = pd.CreatedDate,
                    creatorIP = pd.CreatorIP,
                    field1 = pd.Field1,
                    field2 = pd.Field2,
                    field3 = pd.Field3,
                    field4 = pd.Field4,
                    pricePerUnit = pd.PricePerUnit,
                    productMatrialName = pd.productMaterial?.ProductMatrialName,
                    productOrderID = pd.ProductOrderID,
                    productShadeName = pd.productShade?.ProductShadeName,
                    productTypeImagePath = pd.productType.ProductTypeImagePath,
                    productTypeName = pd.productType.ProductTypeName,
                    quantity = pd.Quantity,
                    toothSelection = pd.ToothSelection,
                    DeliveryDate = pd.DeliveryDate
                });
            }
            vm_OrderView _OrderView = new vm_OrderView()
            {
                OrderProducts = _OrderProductViews,
                createdDate = orderDetails.CreatedDate,
                creatorIP = orderDetails.CreatorIP,
                orderID = orderDetails.OrderID,
                orderNumber = orderDetails.OrderNumber,
                patientAge = orderDetails.PatientAge,
                patientGender = orderDetails.PatientGender,
                patientName = orderDetails.PatientName,
                totalPrice = orderDetails.TotalPrice,
                CurrentStatus = orderDetails.CurrentOrderStatusID,
                StatusList = _orderStatusMaster.GetDoctorStatus((int)orderDetails.LaboratiryID, orderDetails.UserID),
                DoctorDetails = doctorRepo.GetDoctorDetails(orderDetails.UserID),
                doctorClinic = doctorClinic.GetDoctorClinic((int)orderDetails.ClinicID)
            };
            return Ok(_OrderView);
        }

        [HttpPost]
        public IActionResult AddOrderStatus(vm_OrderStatus orderStatus)
        {
            try
            {
                OrderStatus status = new OrderStatus()
                {
                    OrderID = orderStatus.OrderID,
                    OrderStatusMasterID = orderStatus.StatusID
                };

                var result = _orderStatus.AddOrderStatus(status);
                if (result > 0)
                {
                    orderManage.SetCurrentStatus(orderStatus.OrderID, orderStatus.StatusID);
                    responceMessages.Success("Successfully Added Order Status");
                }
                else
                {
                    responceMessages.Failed("Someting went wrong");
                }
                return Ok(responceMessages);
            }
            catch (Exception exp)
            {
                responceMessages.Failed(exp.Message);
                return BadRequest(responceMessages);
            }
        }

        [HttpGet]
        public IActionResult GetOrderStatus(int OrderID)
        {
            try
            {
                var result = _orderStatus.GetOrderStatuses(OrderID);
                List<vm_OrderStatus> _OS = result.Select(s => new vm_OrderStatus
                {
                    id = s.id,

                }).ToList();
                return Ok(_OS);
            }
            catch (Exception exp)
            {
                responceMessages.Failed(exp.Message);
                return BadRequest(responceMessages);
            }
        }

        [HttpPost]
        public IActionResult OrderAssigntoLab(LabAssignment assignment)
        {
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var LoginUser = authentication.GetLogin(claimsIdentity.Name);
            if(LoginUser.RoleID == 2)
            {
                assignment.ParentLabID = LoginUser.UserID;
                if(assignment.ChildLabID == 0)
                {
                    assignment.ChildLabID = assignment.ParentLabID;
                }
                var resp = labAssignment.AssignmentToLab(assignment);
                if (resp > 0)
                {
                    orderManage.NotAcceptOrder(assignment.OrderID);
                    responceMessages.Success("Successfully Assign to Lab");
                    return Ok(responceMessages);
                }
                else
                {
                    responceMessages.Failed("Oops something went wrong");
                    return BadRequest(responceMessages);
                }
            }
            else
            {
                responceMessages.Failed("Invalid User Login");
                return BadRequest(responceMessages);
            }
            

        }

        [HttpPost]
        public IActionResult AcceptOrder(int orderID)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var LoginUser = authentication.GetLogin(claimsIdentity.Name);
            if (LoginUser.RoleID == 2)
            {
               var resp =  orderManage.AcceptOrder(orderID);
                if (resp > 0)
                {
                    responceMessages.Success("Successfully Accepted Order");
                    return Ok(responceMessages);
                }
                else
                {
                    if (resp == -1)
                    {
                        responceMessages.Failed("No process manager exist for this lab.");
                        return BadRequest(responceMessages);
                    }
                    if (resp == -2)
                    {
                        responceMessages.Failed("Order already accepted and assigned to process manager.");
                        return BadRequest(responceMessages);
                    }
                    else
                    {
                        responceMessages.Failed("Oops something went wrong");
                        return BadRequest(responceMessages);
                    }
                }
            }
            else
            {                
                responceMessages.Failed("Invalid User Login");
                return BadRequest(responceMessages);
            }


        }

        //Get orders for employee based on username and user role
        [HttpGet]
        public IActionResult GetOrdersForEmployee(string userName, string userRole)
        {
            try
            {
                var result = orderManage.GetOrdersForEmployee(userName,userRole);
                //List<vm_OrderStatus> _OS = result.Select(s => new vm_OrderStatus
                //{
                //    id = s.id,

                //}).ToList();
                return Ok(result);
            }
            catch (Exception exp)
            {
                responceMessages.Failed(exp.Message);
                return BadRequest(responceMessages);
            }
        }

        //Not in use Can come handing in future
        //[HttpGet]
        //public IActionResult GetProccessEmployeeDetails(int LabID)
        //{
        //    try
        //    {
        //        var result = labAssignment.GetProccessEmployeeDetails(LabID);                
        //        return Ok(result);
        //    }
        //    catch (Exception exp)
        //    {
        //        responceMessages.Failed(exp.Message);
        //        return BadRequest(responceMessages);
        //    }
        //}

        [HttpPost]
        public IActionResult OrderProcessCompleted(int OrderID, string Remarks)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var LoginUser = authentication.GetLogin(claimsIdentity.Name);
            if (LoginUser.RoleID == 4)
            {
                var result = orderManage.OrderProcessCompleted(LoginUser.UserName, OrderID, Remarks);

                if (result == 0)
                {
                    responceMessages.Success("All processes completed.");
                    return Ok(responceMessages);
                }
                if (result == 1)
                {
                    responceMessages.Success("Order moved to next process manager in the doctor preferred queue.");
                    return Ok(responceMessages);
                }
                if (result == 2)
                {
                    responceMessages.Success("Order is completed. Please collect payment and proceed with delivery.");
                    return Ok(responceMessages);
                }
                else
                {
                    if (result == -1)
                    {
                        responceMessages.Failed("No process manager exist for this lab.");
                        return BadRequest(responceMessages);
                    }
                    
                    else
                    {
                        responceMessages.Failed("Oops something went wrong");
                        return BadRequest(responceMessages);
                    }
                }                
            }
            else
            {
                responceMessages.Failed("Invalid User Login");
                return BadRequest(responceMessages);
            }


        }
    }
}
