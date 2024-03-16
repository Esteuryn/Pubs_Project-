using pubs.Application.Core;
using pubs.Application.Models;
using pubs.Application.Models.Store;

namespace pubs.Application.Contracts
{
    public interface IJobService
    {
        ServiceResult<List<JobGetModel>> GetSJob();
        ServiceResult<JobGetModel> GetJob(string id);
        ServiceResult<JobGetModel> SaveJob(JobDto jobDto);
        ServiceResult<JobGetModel> UpdateJob(JobDto job);
        ServiceResult<JobGetModel> RemoveJob(JobDto jobDto);
    }
}