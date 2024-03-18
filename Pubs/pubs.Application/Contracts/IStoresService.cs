using pubs.Application.Core;
using pubs.Application.Dtos.Store;
using pubs.Application.Models.Store;

namespace pubs.Application.Contracts
{
    public interface IStoresService : IBaseService<StoreAddDto, StoreRemoveDto, StoreUpdateDto, StoreGetModel>
    {
        
    }
}
