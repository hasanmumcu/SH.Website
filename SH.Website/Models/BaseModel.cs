using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SH.Website.Models
{
    public abstract class BaseModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool Active { get; set; } = true;

        [ScaffoldColumn(false)]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
