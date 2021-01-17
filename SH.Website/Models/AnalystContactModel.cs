using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models
{
    public class AnalystContactModel : BaseModel
    {
        public string to { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }



    }
}
