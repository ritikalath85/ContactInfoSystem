using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfoSystem.App.Helpers
{
    public class FileHelper : IFileHelper
    {
        IWebHostEnvironment _env;
        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void UploadFile(IFormFile file, string foldername, string fileName)
        {
            var uploads = Path.Combine(_env.WebRootPath, "images", foldername);
            bool exists = Directory.Exists(uploads);
            if (!exists)
                Directory.CreateDirectory(uploads);

            //saving file
            var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
            file.CopyToAsync(fileStream);
        }

        public string ValidateFile(int size, string[] fileExtensions, IFormFile formFile)
        {
            string strReturnMessage = "Pass";
            if (formFile.Length > (2048 * 1024))
            {
                strReturnMessage = "File size cannot be more than 2MB";
            }
            else if (!fileExtensions.Contains(formFile.ContentType))
            {
                strReturnMessage = "Only png, jpeg and jpg files are allowed";
            }
            //string contentTYpe = formFile.ContentType;
            return strReturnMessage;
        }

        public string FormatFileName(IFormFile file, string Append = "img_")
        {
            string strFileName = string.Empty;
            string[] strName = file.FileName.Split('.');
            strFileName = string.Format("{0}{1}.{2}", Append, DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff"), strName[strName.Length - 1]);
            return strFileName;
        }
    }
}
