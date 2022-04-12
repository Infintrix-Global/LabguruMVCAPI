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

        public DocumentController(ResponceMessages responceMessages)
        {
            this.responceMessages = responceMessages;
        }
        [HttpPost]
        public async Task<IActionResult> ImprestionUpload(List<IFormFile> files)
        {
            string[] permittedExtensions = { ".png", ".jpg", "jpeg", "gif" };
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
    }
}
