﻿

namespace pubs.Application.Models.Store
{
    public class JobGetModel
    {
        public short job_id { get; set; }
        public string? job_desc { get; set; }
        public byte Min_lvl { get; set; }
        public byte Max_lvl { get; set; }
    }
}
