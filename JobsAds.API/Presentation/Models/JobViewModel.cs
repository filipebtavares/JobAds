using JobsAds.API.Domain.Entity;

namespace JobsAds.API.Presentation.Models
{
    public class JobViewModel
    {
        public string Title { get;   set; }
        public string Description { get;   set; }
        public string Location { get;   set; }
        public decimal Salary { get;   set; }

        public JobViewModel(string title, string description, string location, decimal salary)
        {
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
        }

        public static JobViewModel FromEntity(Job job)
            => new JobViewModel(job.Title, job.Description, job.Location, job.Salary);

      
    }
}
