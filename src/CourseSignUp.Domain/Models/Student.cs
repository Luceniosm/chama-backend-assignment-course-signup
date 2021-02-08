using System;

namespace CourseSignUp.Domain.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Student(Guid id, string email, string name, DateTime dateOfBirth)
        {
            Id = id;
            Email = email;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public void AlterEmail(string email)
        {
            Email = email?.Trim();
        }

        public void AlterName(string name)
        {
            Name = name?.Trim();
        }


    }
}
