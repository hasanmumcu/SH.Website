using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models.ViewModels
{
    public partial class BaseViewModel
    {
        public Guid MyProperty { get; set; } = Guid.NewGuid();
    }
}
