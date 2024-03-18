using pubs.Application.Core;

namespace pubs.Application.Contracts
{
    public interface IBaseService<TDtoAdd, TDtoRemove, TDtoUpdate, TModel>
    {
        ServiceResult<List<TModel>> GetAll();
        ServiceResult<TModel> Get(string id);
        ServiceResult<TModel> Save(TDtoAdd storeAddDto);
        ServiceResult<TModel> Update(TDtoUpdate storeUpdateDto);
        ServiceResult<TModel> Remove(TDtoRemove storeRemoveDto);
    }
}
