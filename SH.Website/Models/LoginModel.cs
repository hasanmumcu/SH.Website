using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SH.Website.Authentication;

namespace SH.Website.Models
{
    public class LoginModel : BaseModel
    {
        
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}
