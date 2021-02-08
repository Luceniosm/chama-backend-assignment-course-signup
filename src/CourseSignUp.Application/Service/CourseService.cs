using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseSignUp.Api.Courses;
using CourseSignUp.Api.Statistics;
using CourseSignUp.Application.Interface;
using CourseSignUp.Domain.Interface.Service;
using CourseSignUp.Domain.Models;
using CourseSignUp.Domain.Uow;
using CourseSignUp.DTO;

namespace CourseSignUp.Application.Service
{
    public class CourseService: BaseAppService, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISignUpToCourseRepository _signUpToCourseRepository;
        public CourseService(
            IUnitOfWork uow,
            ICourseRepository courseRepository, ISignUpToCourseRepository signUpToCourseRepository) : base(uow)
        {
            _courseRepository = courseRepository;
            _signUpToCourseRepository = signUpToCourseRepository;
        }

        public async Task<Response<SignUpResult>> SignUpToCourse(SignUpToCourseDto signUpToCourse)
        {
            var course = _courseRepository.GetById(signUpToCourse.IdCourse);
            if (course == null)
                return new Response<SignUpResult>(false, "Course Id not found!", null);

            if (await GetIsFullCapacity(course.Capacity, course.Id))
                return new Response<SignUpResult>(false, "Course is full!", null);

            var singUp = new SignUpToCourse(
                Guid.NewGuid(),
                signUpToCourse.IdCourse
            );

            singUp.AlterStudent(
                 new Student(Guid.NewGuid(),
                    signUpToCourse.Student.Name,
                    signUpToCourse.Student.Email,
                    signUpToCourse.Student.DateOfBirth
            ));

            _signUpToCourseRepository.Add(singUp);

            Commit();
            return new Response<SignUpResult>(false, String.Empty, new SignUpResult
            {
                Message = "Congratulations, singUp is complete"
            });
        }

        public async Task<List<CourseStatisticsDto>> Statistics()
        {
            var signUpToCourses= await _signUpToCourseRepository.GetAllWithCourseStudent();
            var courseStatistics = new List<CourseStatisticsDto>();

            if (!signUpToCourses.Any()) return courseStatistics;

            var courses =
                from signUpToCourse in signUpToCourses
                group signUpToCourse by signUpToCourse.IdCourse
                into newSignUpToCourse
                select newSignUpToCourse;

            courseStatistics
                .AddRange(
                    from course in courses
                    let dates = course
                        .Select(_ => _.Student.DateOfBirth)
                        .OrderBy(_ => _.Date).ToList()
                    select new CourseStatisticsDto
                    {
                        Name = course.FirstOrDefault()?.Course.Description,
                        AverageAge = Convert.ToInt16(dates.Average(_ => (DateTime.Now.Year - _.Year))),
                        MaximumAge = DateTime.Now.Year - dates.FirstOrDefault().Date.Year,
                        MinimumAge = DateTime.Now.Year - dates.LastOrDefault().Date.Year
                    });

            return courseStatistics;
        }

        private async Task<bool> GetIsFullCapacity(int courseCapacity, Guid IdCourse)
        {
            var signUp = await _signUpToCourseRepository.GetSignUpByIdCourse(IdCourse);
            return signUp.Count >= courseCapacity;
        }
    }
}
