using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductSettingController : ControllerBase
    {
        private readonly IProductSetting productSetting;
        private readonly ResponceMessages responceMessages;

        public ProductSettingController(IProductSetting productSetting,
            ResponceMessages responceMessages)
        {
            this.productSetting = productSetting;
            this.responceMessages = responceMessages;
        }
        [HttpGet]
        public IActionResult GetProductDeliveryDays(int productID)
        {
            var result = productSetting.GetProductDeliveryDays(productID);
            if (result == null)
            {
                return NotFound(responceMessages.Failed("Product Delivery Days is not Added."));
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult SetProductDeliveryDays(ProductSetting products)
        {
            var prod = productSetting.GetProductDeliveryDays(products.ProductID);
            if (prod != null)
            {
                productSetting.UpdateDeliveryDays(products);
                return Ok(responceMessages.Success("Successfully Updated Product Delivery Days"));
            }
            else
            {
                productSetting.AddDeliveryDays(products);
                return Ok(responceMessages.Success("Successfully Added Product Delivery Days"));
            }
        }
    }
}
