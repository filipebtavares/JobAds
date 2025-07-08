namespace JobsAds.API.Domain.Entity
{
    public class Job
    {
        public int Id { get; private set; }
        public string  Title { get; private set; }
        public string  Description { get; private set; }
        public string Location { get; private set; }
        public decimal Salary { get; private set; }
        public bool  IsDeleted { get; private set; }


        public Job()
        {
        }

        public Job(string title, string description, string location, decimal salary)
        {
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
            IsDeleted = false;
        }

        public void JobDelted()
        {
            IsDeleted = true;
        }

        public void UpdateJob(string title, string description, string location, decimal salary)
        {
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
        }


    }
}
