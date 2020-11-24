using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models
{
    public class User : BaseModel
    {
 
        public Guid UserId { get; set; } 
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Boolean Active { get; set; }
        public DateTime TimeStamp { get; set; }
        public string READ_ONLY { get; internal set; }
        public string ACCESS_LEVEL { get; internal set; }
    }
}
