using pubs.Application.Core;
using pubs.Application.Dtos.Store;
using pubs.Application.Models.Store;

namespace pubs.Application.Contracts
{
    public interface IStoresService
    {
        ServiceResult<List<StoreGetModel>> GetStores();
        ServiceResult<StoreGetModel> GetStore(string id);
        ServiceResult<StoreGetModel> SaveStore(StoreAddDto storeAddDto);
        ServiceResult<StoreGetModel> UpdateStore(StoreUpdateDto storeUpdateDto);
        ServiceResult<StoreGetModel> RemoveStore(StoreRemoveDto storeRemoveDto);
    }
}
