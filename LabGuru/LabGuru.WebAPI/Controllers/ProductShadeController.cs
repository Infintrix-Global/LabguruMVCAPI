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
    public class ProductShadeController : ControllerBase
    {
        private readonly IProductShade productShade;

        public ProductShadeController(IProductShade productShade)
        {
            this.productShade = productShade;
        }
        [HttpGet]
        public IActionResult GetProductShades()
        {
            var result = productShade.GetProductShades();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetProductShade(int ProductShadeID)
        {
            var result = productShade.GetProductShade(ProductShadeID);
            if (result == null)
                return NotFound("Invalid Product Shade Search");

            return Ok(result);
        }
    }
}
