using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]    
    public class DocumentController : ControllerBase
    {
        private readonly ResponceMessages responceMessages;
        readonly string[] permittedExtensions = { ".png", ".jpg", "jpeg", "gif" };
         
        public DocumentController(ResponceMessages responceMessages)
        {
            this.responceMessages = responceMessages;
            
        }
        private string GetAbsolutePath(string RelativePath)
        {
            Uri baseUri = new Uri($"{Request.Scheme}://{Request.Host.Value}");
            if("www.infintrixindia.com" == Request.Host.Value)
            {
                baseUri = new Uri($"{Request.Scheme}://{Request.Host.Value}/LabguruAPI");
            }
            Uri UploadPath = new Uri(baseUri, RelativePath) ;
            return UploadPath.AbsoluteUri;
        }
        [HttpPost]
        public async Task<IActionResult> ImprestionUpload(List<IFormFile> files)
        {
            List<string> UploadedFilesPath = new List<string>() ;
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                var ext = Path.GetExtension(formFile.FileName).ToLowerInvariant();
                if (!permittedExtensions.Contains(ext))
                    return BadRequest(responceMessages.Failed("Invalid File Extension : " + ext));
            }

            var folderName = Path.Combine("Document", "Impration");
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    var dbPath =  Path.Combine(folderName, fileName);
                    var filePath = Path.Combine(pathToSave, fileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                       
                        UploadedFilesPath.Add(dbPath);
                        await formFile.CopyToAsync(stream);
                    }
                }

            }

            return Ok(responceMessages.Success("Successfully Uploaded "+ files.Count +" file(s)", UploadedFilesPath));
        }
        [HttpPost]
        public async Task<IActionResult> ProductType(List<IFormFile> files)
        {
           
            List<string> UploadedFilesPath = new List<string>();
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                var ext = Path.GetExtension(formFile.FileName).ToLowerInvariant();
                if (!permittedExtensions.Contains(ext))
                    return BadRequest(responceMessages.Failed("Invalid File Extension : " + ext));
            }

            var folderName = Path.Combine("Document", "ProductType");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                    var fileName =  ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    var dbPath = Path.Combine(folderName, fileName);
                    var filePath = Path.Combine(pathToSave, fileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        UploadedFilesPath.Add(GetAbsolutePath(dbPath));
                        await formFile.CopyToAsync(stream);
                    }
                }

            }

            return Ok(responceMessages.Success("Successfully Uploaded " + files.Count + " file(s)", UploadedFilesPath));
        }
    }
}
