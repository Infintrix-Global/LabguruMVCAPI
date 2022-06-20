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

            var res = productTypeManage.CreateProductType(productType);
            return res > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult CreateProductType_new([FromForm] vm_ProductType_Create productTypeCreate)
        {
            try
            {
                if(productTypeManage.GetProductType(productTypeCreate.ProductTypeName) == null)
                {
                    string ProductTypeImagePath = string.Empty;
                    if (productTypeCreate.formFiles != null && productTypeCreate.formFiles.Count > 0)
                    {
                        UploadDocument uploadDocument = new UploadDocument(Request);
                        var ddd = uploadDocument.UploadImages(productTypeCreate.formFiles, Models.Enums.DocumentTypes.ProductTypeImage);
                        ProductTypeImagePath = ddd[0];
                    }

                    ProductType productType = new ProductType()
                    {
                        CreatorIP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        isImpressionMindatory = productTypeCreate.isImpressionMindatory,
                        ProductTypeImagePath = ProductTypeImagePath,
                        ProductTypeName = productTypeCreate.ProductTypeName,
                        UpdatorIP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),

                    };
                    var res = productTypeManage.CreateProductType(productType);
                    return res > 0 ? Ok(responceMessages.Success("Successfully Added")) : Ok(responceMessages.Failed("Oops something went wrong"));
                }
                else
                {
                    return BadRequest(responceMessages.Failed("Product Already Exists"));
                }
            }
            catch (Exception exp)
            {
           return BadRequest(  responceMessages.Failed(exp.Message));
            }
        }
    }
}
