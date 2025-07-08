using JobsAds.API.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace JobsAds.API.Presentation.Models
{
    public class CreateJobModel
    {
        [Required]
        [StringLength(30)]
        public string Title { get;   set; }
        [Required]
        [StringLength(1000)]
        public string Description { get;   set; }
        [Required]
        [StringLength(200)]
        public string Location { get;   set; }

        [Required]
        public decimal Salary { get;   set; }


        public Job ToEntity()
            => new(Title, Description, Location, Salary);
    }
}
