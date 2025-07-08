using JobsAds.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace JobsAds.API.Infrastructure.Persistence
{
    public class JobAdsDbContext : DbContext 
    {
        public JobAdsDbContext(DbContextOptions<JobAdsDbContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Job>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Job>()
                .Property(e => e.Salary);

            builder.Entity<Job>()
                .Property(e => e.Title);


            builder.Entity<Job>()
                .Property(e => e.Description);

            builder.Entity<Job>()
                .Property(e => e.Location);

            base.OnModelCreating(builder);
        }
    }
}
