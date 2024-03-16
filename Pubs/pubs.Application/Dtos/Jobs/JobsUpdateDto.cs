using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Application.Dtos.Store
{
    public class JobsUpdateDto : JobSDtoBase  
    {
        public short job_id { get; set; }
    }
}