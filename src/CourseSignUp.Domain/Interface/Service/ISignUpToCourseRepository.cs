using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseSignUp.Domain.Interface.Repository;
using CourseSignUp.Domain.Models;

namespace CourseSignUp.Domain.Interface.Service
{
    public interface ISignUpToCourseRepository: IRepository<SignUpToCourse>
    {
        Task<List<SignUpToCourse>> GetSignUpByIdCourse(Guid IdCourse);
        Task<List<SignUpToCourse>> GetAllWithCourseStudent();
    }
}
