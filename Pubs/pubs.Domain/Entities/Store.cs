using pubs.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Domain.Entities
{
    public class Store : BaseEntity
    {
        public bool deleted;

        public int stor_id { get; set; }
        public string? stor_name { get; set; }
        public string? stor_address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip { get; set; }
    }
}
