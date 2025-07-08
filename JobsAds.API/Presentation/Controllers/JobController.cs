using JobsAds.API.Application.Service;
using JobsAds.API.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace JobsAds.API.Presentation.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _service;

        public JobController(IJobService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var result = await _service.GetJobs();

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var result = await _service.GetJobById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostJob(CreateJobModel model)
        {
            var result = await _service.PostJob(model);

            return CreatedAtAction(nameof(GetJobById), new { id = result.Data }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobModel model)
        {
            var result = await _service.UpdateJob(id, model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await _service.DeletedJob(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
