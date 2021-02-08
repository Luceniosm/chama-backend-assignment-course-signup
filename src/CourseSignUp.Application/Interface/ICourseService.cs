using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseSignUp.Api.Courses;
using CourseSignUp.Api.Statistics;
using CourseSignUp.DTO;

namespace CourseSignUp.Application.Interface
{
    public interface ICourseService
    {
        Task<Response<SignUpResult>> SignUpToCourse(SignUpToCourseDto signUpToCourse);
        Task<List<CourseStatisticsDto>> Statistics();
    }
}
