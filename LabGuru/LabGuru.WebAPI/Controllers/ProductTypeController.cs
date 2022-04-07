using LabGuru.BAL.Repo;
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
        private readonly IProductTypeManage productType;

        public ProductTypeController(IProductTypeManage productType)
        {
            this.productType = productType;
        }
        [HttpGet]
        public IActionResult GetAllProductType()
        {
            var productTypes = productType.GetProductTypes();
            return Ok(productTypes);
        }
        [HttpGet]
        public IActionResult GetProductType(int id)
        {
            var productTypes = productType.GetProductType(id);
            return Ok(productTypes);
        }




    }
}
