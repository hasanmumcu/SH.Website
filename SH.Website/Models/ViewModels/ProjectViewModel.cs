using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string status { get; set; }
        public string clientCompany { get; set; }
        public string projectLeader { get; set; }
        public string estimatedBudget { get; set; }
        public string totalAmountSpent { get; set; }
        public string estimatedProjectDuration { get; set; }
    }
}
