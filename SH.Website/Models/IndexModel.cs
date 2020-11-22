using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Models
{
    public class IndexModel : BaseModel
    {
        public virtual ICollection<PartialModel> Partials { get; set; }
    }
}
