using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeManage productTypeManage;
        private readonly ResponceMessages responceMessages;

        public ProductTypeController(IProductTypeManage productTypeManage,
            ResponceMessages responceMessages)
        {
            this.productTypeManage = productTypeManage;
            this.responceMessages = responceMessages;
        }
        [HttpGet]
        public IActionResult GetAllProductType()
        {
            var productTypes = productTypeManage.GetProductTypes();
            return Ok(productTypes);
        }
        [HttpGet]
        public IActionResult GetProductType(int id)
        {
            var productTypes = productTypeManage.GetProductType(id);
            return Ok(productTypes);
        }
        [HttpPost]
        public IActionResult CreateProductType(ProductType productType)
        {
            productType.CreatorIP = "Test";
            productType.UpdatorIP = "Test";
            
            var res  = productTypeManage.CreateProductType(productType);
            return res > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));
        }
    }
}
