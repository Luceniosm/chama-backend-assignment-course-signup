using CourseSignUp.Domain.Interface.Service;
using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Context;

namespace CourseSignUp.Infra.Data.Repository
{
    public class StudentRepository : _Base.Repository<Student>, IStudentRepository
    {
        public StudentRepository(CourseSignUpContext context) : base(context)
        {
        }
    }
}
