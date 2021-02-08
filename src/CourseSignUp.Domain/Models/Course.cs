using System;

namespace CourseSignUp.Domain.Models
{
    public class Course
    {
        public Guid Id { get; private set; }
        public int Capacity { get; private set; }
        public string Description { get; private set; }

        public Course(Guid id, int capacity, string description)
        {
            Id = id;
            Capacity = capacity;
            Description = description;
        }

        public void AlterCapacity(int capacity)
        {
            Capacity = capacity;
        }

        public void AlterDescription(string description)
        {
            Description = description?.Trim();
        }
    }
}
