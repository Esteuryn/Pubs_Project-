using System;
using System.Collections.Generic;
using System.Text;


namespace pubs.Domain.Entities
{
    public abstract class Jobs
    {
        public short job_id { get; }
        public string? job_desc { get; }
        public byte Min_lvl { get; }
        public byte Max_lvl { get; }
    }
}
