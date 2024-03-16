using pubs.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Domain.Entities
{
    public class Jobs : BaseEntity
    {
        [Key]
        public short job_id { get; set; }
        public string? job_desc { get; set;  }
        public byte Min_lvl { get; set;  }
        public byte Max_lvl { get; set; }
    }
}
