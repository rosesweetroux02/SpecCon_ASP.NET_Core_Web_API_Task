using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupAPP.Domain.Entities
{
    [Table("ProfficiancyLevel", Schema = "dbo")]
    public class ProfficiancyLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfficiancyLevelId { get; set; }

        [Required]
        public Guid ProfficiancyLevelKey { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; } = null!;

        [Required]
        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

        [Required]
        public int RecordStatusId { get; set; } = 1;
    }
}
