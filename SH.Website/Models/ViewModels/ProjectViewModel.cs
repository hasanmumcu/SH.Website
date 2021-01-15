using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        [Key]
        [Required]
        [StringLength(200)]
        public string projectName { get; set; }
        [Required]
        [StringLength(300)]
        public string projectDescription { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        [StringLength(200)]
        public string clientCompany { get; set; }
        [Required]
        [StringLength(200)]
        public string projectLeader { get; set; }
        [Required]
        [StringLength(50)]
        public string estimatedBudget { get; set; }
        [Required]
        [StringLength(50)]
        public string totalAmountSpent { get; set; }
        [Required]
        [StringLength(50)]
        public string estimatedProjectDuration { get; set; }
    }
}
