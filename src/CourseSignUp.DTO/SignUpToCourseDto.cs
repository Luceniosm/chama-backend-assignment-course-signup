using System;

namespace CourseSignUp.Api.Courses
{
    public class SignUpToCourseDto
    {
        public Guid IdCourse { get; set; }
        public StudentDto Student { get; set; }

        public class StudentDto
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
