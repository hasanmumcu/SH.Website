using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SH.Website.Models.ViewModels
{
    public class PartialViewModel : BaseViewModel
    {
        public string PartialName { get; set; }
        public object Model { get; set; }

        public int Order { get; set; }

    }
}
