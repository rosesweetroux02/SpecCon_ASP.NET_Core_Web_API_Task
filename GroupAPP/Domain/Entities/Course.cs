using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupAPP.Domain.Entities
{
    [Table("Course", Schema = "dbo")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        public Guid CourseKey { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string CourseName { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string CourseDescription { get; set; } = null!;

        // Defensive: These allow NULL in your image, so we use string?
        [Column(TypeName = "varchar(50)")]
        public string? NQFLevel { get; set; }

        [Required]
        public int DeliveryMethodId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? UnitstandardNo { get; set; }

        // Decimal Precision mapping
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Credits { get; set; }

        [Required]
        public int LearningSubfieldId { get; set; }

        [Required]
        public int MoodleCourseId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal CoursePrice { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string CourseImage { get; set; } = null!;

        [Required]
        public int CourseAvegerageRating { get; set; }

        [Required]
        public int RecommendedDuration { get; set; }

        // Bit columns map to Bool
        [Required] public bool IsIndividualFree { get; set; }
        [Required] public bool IsIndividualPremiumFree { get; set; }
        [Required] public bool IsCorporateFree { get; set; }
        [Required] public bool IsCorporateFreePremium { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Author { get; set; } = null!;

        [Required] public bool IsDiscount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Required] public bool IsFullCourse { get; set; }
        [Required] public bool IsAssessment { get; set; }
        [Required] public bool IsApproved { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string CourseOverview { get; set; } = null!;

        [Required]
        public int CourseAccessDuration { get; set; }

        [Required]
        public int CertificateId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

        [Required]
        public int RecordStatusId { get; set; } = 1;
    }
}
