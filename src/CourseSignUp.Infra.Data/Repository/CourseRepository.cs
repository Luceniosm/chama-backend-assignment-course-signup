using CourseSignUp.Domain.Interface.Service;
using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Context;

namespace CourseSignUp.Infra.Data.Repository
{
    public class CourseRepository : _Base.Repository<Course>, ICourseRepository
    {
        public CourseRepository(CourseSignUpContext context) : base(context)
        {
        }
    }
}
