using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SH.Website.Models.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
    }
}
