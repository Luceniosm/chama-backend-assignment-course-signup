using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseSignUp.Domain.Interface.Service;
using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseSignUp.Infra.Data.Repository
{
    public class SignUpToCourseRepository : _Base.Repository<SignUpToCourse>, ISignUpToCourseRepository
    {
        public SignUpToCourseRepository(CourseSignUpContext context) : base(context)
        {

        }

        public async Task<List<SignUpToCourse>> GetSignUpByIdCourse(Guid IdCourse)
        {
            return await Db.SignUpToCourses
                .Where(_ =>_.IdCourse == IdCourse)
                .ToListAsync();
        }

        public async Task<List<SignUpToCourse>> GetAllWithCourseStudent()
        {
             return await Db.SignUpToCourses
                 .Include(_ => _.Student)
                 .Include(_ => _.Course)
                 .ToListAsync();
        }
    }
}
