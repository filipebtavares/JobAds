using JobsAds.API.Presentation.Models;

namespace JobsAds.API.Application.Service
{
    public interface IJobService
    {

        Task<ResultViewModel<List<JobViewModel>>> GetJobs();
        Task<ResultViewModel<JobViewModel>> GetJobById(int id);
        Task<ResultViewModel<int>> PostJob(CreateJobModel model);
        Task<ResultViewModel> DeletedJob(int id);
        Task<ResultViewModel> UpdateJob(int id, UpdateJobModel model);
    }
}
