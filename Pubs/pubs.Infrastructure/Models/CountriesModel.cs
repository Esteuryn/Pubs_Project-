using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Infrastructure.Models
{
    public class CountriesModel
    {
        public int createuser { get; set; }
        public int Id { get; set; }
        public DateTime? creationdate { get; set; }
        public int? modifieduser { get; set; }

        public DateTime? modifieddate { get; set; }

        public int? deleteduser { get; set; }

        public DateTime? deleteddate { get; set; }

        public string CountriesName { get; set; }
    }
}

    

