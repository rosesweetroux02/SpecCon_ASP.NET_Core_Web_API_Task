namespace GroupAPP.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string NQFLevel { get; set; }
        public decimal CoursePrice { get; set; }
        public bool IsApproved { get; set; }
        public bool IsAssessment { get; set; }
    }

}
