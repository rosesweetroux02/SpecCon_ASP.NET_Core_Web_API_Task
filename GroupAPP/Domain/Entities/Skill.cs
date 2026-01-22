using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupAPP.Domain.Entities
{
    [Table("Skill", Schema = "dbo")]
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Required]
        public Guid SkillKey { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string SkillName { get; set; } = null!;

        [Required]
        public int ProfficiancyLevelId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

        [Required]
        public int RecordStatusId { get; set; } = 1;

        [Required]
        public bool IsApproved { get; set; }

        
        [Column(TypeName = "varchar(max)")]
        public string? CorrectedSkillName { get; set; }
    }
}
