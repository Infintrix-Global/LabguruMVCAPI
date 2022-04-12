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

        public OrderController(IOrderManage orderManage, IAuthentication authentication, IOrderStatus _orderStatus,
            ResponceMessages responceMessages)

        {
            this.orderManage = orderManage;
            this.authentication = authentication;
            this._orderStatus = _orderStatus;
            this.responceMessages = responceMessages;
        }

        [HttpPost]
        public IActionResult CreateOrder(vm_OrderCreate orderCreate)
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
                TotalPrice = 0,
                UserID = LoginUser.UserID,
                ClinicID = orderCreate.ClinicID,
                ProcessID = orderCreate.ProcessID,
                LaboratiryID = orderCreate.LaboratiryID
            };
            if (orderManage.CreateOrder(orderDetails) > 0)
            {
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
                    UserID = LoginUser.UserID

                };
                if (orderManage.CreateOrderProduct(productOrder) > 0)
                {
                    ResponceMessages responceMessages = new ResponceMessages()
                    {
                        Data = new { orderDetails.OrderNumber, orderDetails.OrderID },
                        isSuccess = true,
                        Message = "Order Placed Successfully"
                    };
                    return Ok(responceMessages);
                }
            }
            return BadRequest("Something want wrong");

        }

        [HttpGet]
        public IActionResult GetOrderList()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            int LoginUserID = authentication.GetLogin(claimsIdentity.Name).UserID;
            var result = orderManage.GetOrderDetails(LoginUserID);
            return Ok(result);
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
                    productMatrialName = pd.productMaterial.ProductMatrialName,
                    productOrderID = pd.ProductOrderID,
                    productShadeName = pd.productShade.ProductShadeName,
                    productTypeImagePath = pd.productType.ProductTypeImagePath,
                    productTypeName = pd.productType.ProductTypeName,
                    quantity = pd.Quantity,
                    toothSelection = pd.ToothSelection
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
                totalPrice = orderDetails.TotalPrice
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
                    Remarks = orderStatus.Remarks,
                    Status = orderStatus.StatusText
                };
                var result = _orderStatus.AddOrderStatus(status);
                if (result > 0)
                {
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
                    Remarks = s.Remarks,
                    StatusText = s.Status,
                    CreateDate = s.CreateDate
                }).ToList();
                return Ok(_OS);
            }
            catch (Exception exp)
            {
                responceMessages.Failed(exp.Message);
                return BadRequest(responceMessages);
            }
        }
    }
}
