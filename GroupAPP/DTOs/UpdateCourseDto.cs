namespace GroupAPP.DTOs
{
    public class UpdateCourseDto
    {
        public required string CourseName { get; set; }
        public required string CourseDescription { get; set; }
        public decimal CoursePrice { get; set; }
    }
}
