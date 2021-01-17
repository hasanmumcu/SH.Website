using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace SH.Website.Models.ViewModels
{
    public class FileManagerViewModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IFormFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; }
    }
}
