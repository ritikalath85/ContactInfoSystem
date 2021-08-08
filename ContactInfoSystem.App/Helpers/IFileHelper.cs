using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfoSystem.App.Helpers
{
    public interface IFileHelper
    {
        void UploadFile(IFormFile file, string foldername, string fileName);

        string ValidateFile(int size, string[] fileExtensions, IFormFile formFile);

        string FormatFileName(IFormFile file, string Append = "img_");
    }
}
