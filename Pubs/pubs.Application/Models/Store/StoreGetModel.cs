using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Application.Models.Store
{
    public class StoreGetModel
    {
        public string? StoreName { get; set; }
        public string storeId { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
