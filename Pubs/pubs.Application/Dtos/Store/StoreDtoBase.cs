using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Application.Dtos.Store
{
    public class StoreDtoBase : DtoBase
    {
        public string storeId { get; set; }
        public string? StoreName { get; set; }
    }
}
