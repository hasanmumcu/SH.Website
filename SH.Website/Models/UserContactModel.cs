using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models
{
    public class UserContactModel:BaseModel
    {
        public string to { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
