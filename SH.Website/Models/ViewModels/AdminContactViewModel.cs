using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models.ViewModels
{
    public class AdminContactViewModel : BaseViewModel
    {
  
        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string to { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [StringLength(500)]
        [DataType(DataType.Upload)]
        public string Attachment { get; set; }




    }
}
