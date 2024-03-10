namespace pubs.Infrastructure.Models
{
    public class JobsModel
    {
        public short job_id { get; }
        public string? job_desc { get; }
        public byte min_lvl { get; }
        public byte max_lvl { get; }
    }
}
