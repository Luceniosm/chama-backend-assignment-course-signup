namespace CourseSignUp.Api.Statistics
{
    public class CourseStatisticsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public int AverageAge { get; set; }
    }
}
