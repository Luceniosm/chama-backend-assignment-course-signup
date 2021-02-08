using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseSignUp.Api.Courses;

namespace CourseSignUp.Received
{
    public static class Utils
    {
        public static SignUpToCourseDto GetRandonValues()
        {
            var name = GetName();

            return new SignUpToCourseDto()
            {
                IdCourse = GetIdCourse(),
                Student = new SignUpToCourseDto.StudentDto
                {
                    Name = name,
                    Email = name + "@courses.com",
                    DateOfBirth = GetDateOfBirth()
                }
            };
        }
        public static string GetName()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public static Guid GetIdCourse()
        {
            var idsCourse = new List<Guid>(new Guid[] {
                Guid.Parse("097D4EDF-C0AA-4586-877E-7E78F84DE25C"),
                Guid.Parse("0D558D6B-ECD5-4A65-8624-9A0E6430BDAE"),
                Guid.Parse("639E7F4B-4E1F-448E-8AA7-782B8E0FDE58"),
                Guid.Parse("7CD9A57F-D658-4DF9-B71F-5162EAC9CAEC"),
                Guid.Parse("0E7C0FCE-9012-4FA3-85DC-CAFEF469A8D6"),
                Guid.Parse("84DF4328-5194-41B1-A88C-1A20E5AB0AAE"),
                Guid.Parse("0916C70F-F2B9-431B-86CF-49C97B024F3D")
            });

            var random = new Random();
            return idsCourse.OrderBy(s => random.NextDouble()).First();
        }


        public static DateTime GetDateOfBirth()
        {
            var random = new Random();
            DateTime start = new DateTime(1980, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
