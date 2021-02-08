using System;

namespace CourseSignUp.Domain.Models
{
    public class SignUpToCourse
    {
        public Guid Id { get; private set; }
        public Guid IdStudent { get; private set; }
        public Guid IdCourse { get; private set; }

        public virtual Student Student{ get; protected set; }
        public virtual Course Course { get; protected set; }

        public SignUpToCourse(Guid id, Guid idCourse)
        {
            Id = id;
            IdCourse = idCourse;            
        }

        public void AlterStudent(Student student)
        {
            Student = student;
        }
    }
}
