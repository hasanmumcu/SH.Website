using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models
{
    public class PartialModel  : BaseModel 
    {
        public Guid IndexModelId { get; set; }
        public string PartialName { get; set; }
        public int PartialCode { get; set; }
        public string PartialCodeValue { get; set; }
        public int Order { get; set; }

        public virtual IndexModel  IndexModel { get; set; }
    }
}
 