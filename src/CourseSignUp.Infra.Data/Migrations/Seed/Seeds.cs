using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseSignUp.Infra.Data.Migrations.Seed
{
    public class Seeds
    {
        private readonly CourseSignUpContext _context;

        public Seeds(CourseSignUpContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddCourse(new Course(Guid.Parse("097D4EDF-C0AA-4586-877E-7E78F84DE25C"), 100, "Business Essentials"));
            AddCourse(new Course(Guid.Parse("0D558D6B-ECD5-4A65-8624-9A0E6430BDAE"), 50, "Leadership & Management"));
            AddCourse(new Course(Guid.Parse("639E7F4B-4E1F-448E-8AA7-782B8E0FDE58"), 30, "Entrepreneurship & Innovation"));
            AddCourse(new Course(Guid.Parse("7CD9A57F-D658-4DF9-B71F-5162EAC9CAEC"), 20, "Strategy"));
            AddCourse(new Course(Guid.Parse("0E7C0FCE-9012-4FA3-85DC-CAFEF469A8D6"), 40, "Analytics"));
            AddCourse(new Course(Guid.Parse("84DF4328-5194-41B1-A88C-1A20E5AB0AAE"), 50, "Finance & Accounting"));
            AddCourse(new Course(Guid.Parse("0916C70F-F2B9-431B-86CF-49C97B024F3D"), 10, "Business in Society"));
        }

        private void AddCourse(Course course)
        {
            var existingType = _context.Courses.FirstOrDefault(p => p.Id == course.Id);
            if (existingType == null)
            {
                _context.Courses.Add(course);
            }
        }
    }
}
