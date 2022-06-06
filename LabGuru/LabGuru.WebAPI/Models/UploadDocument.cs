using LabGuru.WebAPI.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class UploadDocument
    {
        readonly string[] permittedExtensions = { ".png", ".webp", ".svg", ".jpg", "jpeg", "gif" };
        private readonly HttpRequest httpRequest;

        public UploadDocument(HttpRequest httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        private string GetAbsolutePath(string RelativePath)
        {
            Uri baseUri = new Uri($"{httpRequest.Scheme}://{httpRequest.Host.Value}");
            //if (httpRequest.Host.Value.ToLower().Equals("www.infintrixindia.com"))
            //{
            //    RelativePath = $"LabguruAPI/{RelativePath}";
            //}
            Uri UploadPath = new Uri(baseUri,   RelativePath);
            return UploadPath.AbsoluteUri;
        }
        public List<string> UploadImages(List<IFormFile> files, DocumentTypes documents)
        {
            string DFolder = string.Empty;
            if (DocumentTypes.ImpressionImage == documents)
                DFolder = "Impression";
            else if (DocumentTypes.ProductTypeImage == documents)
                DFolder = "ProductType";
            else
                DFolder = "TempFolder";

            List<string> UploadedFilesPath = new List<string>();
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                var ext = Path.GetExtension(formFile.FileName).ToLowerInvariant();
                if (!permittedExtensions.Contains(ext))
                    throw new Exception("Invalid File Extension : " + ext);
            }

            var folderName = Path.Combine("Document", DFolder);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                    var fileName = string.Format("{0:yyMMddHHmmss}", DateTime.Now) + "_" + ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    var dbPath = httpRequest.Host.Value.ToLower().Equals("www.infintrixindia.com") ? Path.Combine("LabguruAPI", folderName, fileName) : Path.Combine(folderName, fileName);
                    var filePath = Path.Combine(pathToSave, fileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        UploadedFilesPath.Add(GetAbsolutePath(dbPath));
                        formFile.CopyTo(stream);
                    }
                }

            }

            return UploadedFilesPath;
        }
    }
}
