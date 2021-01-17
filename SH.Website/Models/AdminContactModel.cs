
using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SH.Website.Models
{
    public class AdminContactModel : BaseModel
    {
        public string to { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }



    }

}