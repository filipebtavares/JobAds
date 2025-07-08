using JobsAds.API.Infrastructure.Persistence;
using JobsAds.API.Presentation.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsAds.API.Application.Service
{
    public class JobService : IJobService
    {
        private readonly JobAdsDbContext _context;

        public JobService(JobAdsDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> DeletedJob(int id)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(o => o.Id == id);

            if (job is null)
            {
                return ResultViewModel.Erro("This job does not exist!");
            }

            job.JobDelted();
            _context.Update(job);

            return ResultViewModel.Success();

        }

        public async Task<ResultViewModel<JobViewModel>> GetJobById(int id)
        {
            var jobs = await _context.Jobs.SingleOrDefaultAsync(o => o.Id == id);

            if (jobs is null)
            {
                return ResultViewModel<JobViewModel>.Error("This job does not exist!");
            }

            var model = JobViewModel.FromEntity(jobs);

            return ResultViewModel<JobViewModel>.Success(model);

        }

        public async Task<ResultViewModel<List<JobViewModel>>> GetJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();

            var model = jobs.Select(JobViewModel.FromEntity).ToList();

            return ResultViewModel<List<JobViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<int>> PostJob(CreateJobModel model)
        {
            var job = model.ToEntity();

             _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(job.Id);
        }

        public async Task<ResultViewModel> UpdateJob(int id, UpdateJobModel model)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(o => o.Id == id);


            if(job is null)
            {
                return ResultViewModel.Erro("This job does not exist.");
            }

            job.UpdateJob(model.Title, model.Description, model.Location, model.Salary);

            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
    }

