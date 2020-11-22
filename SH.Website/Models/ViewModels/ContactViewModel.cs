using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        public string Subject { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }
    }
}
