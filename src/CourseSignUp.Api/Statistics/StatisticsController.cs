using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CourseSignUp.Application.Interface;

namespace CourseSignUp.Api.Statistics
{
    [ApiController, Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public StatisticsController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet, Route("getStatistics")]
        public async Task<IActionResult> Get()
        {
            var result = await _courseService.Statistics();
            return Ok(result);
        }
    }
}
