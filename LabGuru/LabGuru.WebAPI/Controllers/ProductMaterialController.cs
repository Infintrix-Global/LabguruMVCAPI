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
    public class ProductMaterialController : ControllerBase
    {
        private readonly IProductMaterial productMaterial;

        public ProductMaterialController(IProductMaterial productMaterial)
        {
            this.productMaterial = productMaterial;
        }
        [HttpGet]
        public IActionResult GetProductMaterials()
        {
            var result = productMaterial.GetProductMaterials();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetProductMaterial(int ProductMaterialID)
        {
            var result = productMaterial.GetProductMaterial(ProductMaterialID);
            if (result == null)
                return NotFound("Invalid Product Material Search");

            return Ok(result);
        }
    }
}
