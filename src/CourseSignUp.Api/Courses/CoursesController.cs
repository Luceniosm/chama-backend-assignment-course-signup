using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CourseSignUp.Messege.Interface;

namespace CourseSignUp.Api.Courses
{
    [ApiController, Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IQueueService _queueService;
        public CoursesController(IQueueService queueService)
        {
            _queueService = queueService;
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            // TODO
            return Ok(new CourseDto
            {

            });
        }

        [HttpPost, Route("create")]
        public Task<IActionResult> Post([FromBody]CreateCourseDto createCourseDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("sign-up")]
        public async Task<IActionResult> Post([FromBody] SignUpToCourseDto signUpToCourseDto)
        {
            await _queueService.SendMessageAsync(signUpToCourseDto, "coursequeue");
            return Ok(true);
        }
    }
}
