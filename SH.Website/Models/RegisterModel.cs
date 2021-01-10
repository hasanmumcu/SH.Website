using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SH.Website.Models
{
    public class RegisterModel : BaseModel
    {
    
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string ACCESS_LEVEL { get; set; }

        public string WRITE_ACCESS { get; set; }

    }
}
