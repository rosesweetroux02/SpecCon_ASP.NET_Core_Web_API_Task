namespace GroupAPP.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public required string CourseName { get; set; }
        public required string CourseDescription { get; set; }
        public required string NQFLevel { get; set; }
        public decimal CoursePrice { get; set; }
        public bool IsApproved { get; set; }
        public bool IsAssessment { get; set; }
    }

}
