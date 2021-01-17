using SH.Website.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Web.Helpers;

namespace SH.Website.Models.ViewModels
{
    public class AdminContactViewModel : BaseViewModel
    {

        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string to { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        
        public string Message { get; set; }







    }
}
