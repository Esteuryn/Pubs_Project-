using pubs.Application.Contracts;
using pubs.Application.Core;
using pubs.Application.Dtos.Store;
using pubs.Application.Models.Store;
using pubs.Domain.Entities;
using pubs.Infrastructure.Interfaces;
using pubs.Infrastructure.Logging;
using System.Collections.Immutable;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using pubs.Application.Exceptions;

namespace pubs.Application.Service
{
    public class StoreService : IStoresService
    {
        private readonly CustomLogger _logger;
        private readonly IStoresRepository storesRepository;

        public StoreService(ICustomlogger logger, IStoresRepository storesRepository)
        {
            _logger = (CustomLogger?)logger;
            this.storesRepository = storesRepository;
        }

        public ServiceResult<StoreGetModel> Get(string id)
        {
            ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();
            try
            {
                var store = this.storesRepository.GetEntity(id);

                result.Data = new StoreGetModel()
                {
                    storeId = store.stor_id,
                    StoreName = store.stor_name,
                    City = store.city,
                    State = store.state
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la tienda";
                _logger.LogError(result.Message + ex.ToString());
            }
            return result;
        }

        public ServiceResult<List<StoreGetModel>> GetAll()
        {
            ServiceResult<List<StoreGetModel>> result = new ServiceResult<List<StoreGetModel>>();
            try
            {
                result.Data = this.storesRepository.GetEntities().Select(stores => new StoreGetModel()
                {
                    StoreName = stores.stor_name,
                    storeId = stores.stor_id,
                    State = stores.state,
                    City = stores.city
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las tiendas";
                _logger.LogError(result.Message + ex.ToString());
            }
            return result;
        }

        public ServiceResult<StoreGetModel> Remove(StoreRemoveDto storeRemoveDto)
        {
            ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

            this.storesRepository.Remove(new Store()
            {
                stor_id = storeRemoveDto.storeId
            });

            return result;
        }

        public ServiceResult<StoreGetModel> Save(StoreAddDto storeDto)
        {
            ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

            try
            {
                ValidateStoreDto(storeDto);

                if (this.storesRepository.Exist(stores => stores.stor_name == storeDto.StoreName))
                {
                    result.Success = false;
                    result.Message = $"La tienda {storeDto.StoreName} ya existe.";
                    return result;
                }

                this.storesRepository.Save(new Domain.Entities.Store()
                {
                    stor_name = storeDto.StoreName,
                    stor_id = storeDto.storeId,
                    state = storeDto.State,
                    city = storeDto.City
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la tienda";
                _logger.LogError(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<StoreGetModel> Update(StoreUpdateDto storeDto)
        {
            ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

            try
            {
                ValidateStoreDto(storeDto);

                this.storesRepository.Update(new Store()
                {
                    stor_id = storeDto.storeId,
                    stor_name = storeDto.StoreName,
                    city = storeDto.City,
                    state = storeDto.State
                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la tienda";
                _logger.LogError(result.Message + ex.ToString());
            }

            return result;
        }

        public void ValidateStoreDto(StoreDtoBase storeDto)
        {
            var serviceException = new StoreServiceException();
            ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

            serviceException.ValidateNullable(storeDto.StoreName, "El id de la tienda es requerido", result.Success = false);
            serviceException.ValidateLenght("El id de la tienda debe tener como máximo 4 caracteres.", storeDto.storeId, 4, result.Success = false);
            serviceException.ValidateLenght("El nombre de la tienda debe tener como máximo 40 caracteres.", storeDto.StoreName, 40, result.Success = false);
            serviceException.ValidateLenght("El estado debe tener como máximo 2 caracteres.", storeDto.State, 2, result.Success = false);
            serviceException.ValidateLenght("El nombre de la ciudad debe tener como máximo 20 caracteres.", storeDto.City, 20, result.Success = false);
        }


        //public ServiceResult<StoreGetModel> GetStore(string storeId)
        //{
        //    ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();
        //    try
        //    {
        //        var store = this.storesRepository.GetEntity(storeId);

        //        result.Data = new StoreGetModel()
        //        {
        //            storeId = store.stor_id,
        //            StoreName = store.stor_name,
        //            City = store.city,
        //            State = store.state
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = "Error obteniendo la tienda";
        //        _logger.LogError(result.Message + ex.ToString());
        //    }
        //    return result;
        //}

        //public ServiceResult<List<StoreGetModel>> GetStores()
        //{
        //    ServiceResult<List<StoreGetModel>> result = new ServiceResult<List<StoreGetModel>>();
        //    try
        //    {
        //        result.Data = this.storesRepository.GetEntities().Select(stores => new StoreGetModel()
        //        {
        //            StoreName = stores.stor_name,
        //            storeId = stores.stor_id,
        //            State = stores.state,
        //            City = stores.city
        //        }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = "Error obteniendo las tiendas";
        //        _logger.LogError(result.Message + ex.ToString());
        //    }
        //    return result;
        //}

        //public ServiceResult<StoreGetModel> RemoveStore(StoreRemoveDto storeDto)
        //{
        //    ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

        //    this.storesRepository.Remove(new Store()
        //    {
        //        stor_id = storeDto.storeId
        //    });

        //    return result;
        //}

        //public ServiceResult<StoreGetModel> SaveStore(StoreAddDto storeDto)
        //{
        //    ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

        //    try
        //    {
        //        var serviceException = new StoreServiceException();

        //        serviceException.ValidateNullable(storeDto.StoreName, "El id de la tienda es requerido", result.Success = false);

        //        serviceException.ValidateLenght("El id de la tienda debe tener como maximo 4 caracteres.", storeDto.storeId, 4, result.Success = false);

        //        serviceException.ValidateLenght("El nombre de la tienda debe tener como maximo 40 caracteres.", storeDto.StoreName, 40, result.Success = false);

        //        serviceException.ValidateLenght("El estado debe tener como maximo 2 caracteres.", storeDto.State, 2, result.Success = false);

        //        serviceException.ValidateLenght("El nombre de la ciudad debe tener como mucho 20 caracteres.", storeDto.City, 20, result.Success = false);

        //        if (this.storesRepository.Exist(stores => stores.stor_name == storeDto.StoreName))
        //        {
        //            result.Success = false;
        //            result.Message = $"La tienda {storeDto.StoreName} ya existe.";
        //            return result;
        //        }

        //        this.storesRepository.Save(new Domain.Entities.Store()
        //        {
        //            stor_name = storeDto.StoreName,
        //            stor_id = storeDto.storeId,
        //            state = storeDto.State,
        //            city = storeDto.City
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = "Error guardando la tienda";
        //        _logger.LogError(result.Message + ex.ToString());
        //    }

        //    return result;
        //}

        //    public ServiceResult<StoreGetModel> UpdateStore(StoreUpdateDto storeDto)
        //    {
        //        ServiceResult<StoreGetModel> result = new ServiceResult<StoreGetModel>();

        //        try
        //        {
        //            var serviceException = new StoreServiceException();

        //            serviceException.ValidateNullable(storeDto.StoreName, "El id de la tienda es requerido", result.Success = false);

        //            serviceException.ValidateLenght("El id de la tienda debe tener como maximo 4 caracteres.", storeDto.storeId, 4, result.Success = false);

        //            serviceException.ValidateLenght("El nombre de la tienda debe tener como maximo 40 caracteres.", storeDto.StoreName, 40, result.Success = false);

        //            serviceException.ValidateLenght("El estado debe tener como maximo 2 caracteres.", storeDto.State, 2, result.Success = false);

        //            serviceException.ValidateLenght("El nombre de la ciudad debe tener como mucho 20 caracteres.", storeDto.City, 20, result.Success = false);

        //            this.storesRepository.Update(new Store()
        //            {
        //                stor_id = storeDto.storeId,
        //                stor_name = storeDto.StoreName,
        //                city = storeDto.City,
        //                state = storeDto.State
        //            });

        //        }
        //        catch (Exception ex)
        //        {
        //            result.Success = false;
        //            result.Message = "Error actualizando la tienda";
        //            _logger.LogError(result.Message + ex.ToString());
        //        }

        //        return result;
        //    }
    }
}
