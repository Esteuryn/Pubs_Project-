using pubs.Api.Dtos.Stores;

namespace pubs.Api.Models
{
    public class StoreGetModel
    {
        public string? StoreName { get; set; }
        public string storeId { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
     }
}
