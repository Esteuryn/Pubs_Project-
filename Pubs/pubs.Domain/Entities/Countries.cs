using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Domain
{
    public abstract class Countries 
    {
        public int createuser { get; set; }
        public int Id { get; set; }
        public DateTime? creationdate { get; set; }
        public int? modifieduser { get; set; }

        public DateTime? modifieddate { get; set; }

        public int? deleteduser { get; set; }

        public DateTime? deleteddate { get; set; }

        public string name { get; set; }
    }
}
