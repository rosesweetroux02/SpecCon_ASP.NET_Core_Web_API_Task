namespace GroupAPP.DTOs
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public required string SkillName { get; set; }
        public required string CorrectedSkillName { get; set; }
        public int ProficiencyLevelId { get; set; }
        public bool IsApproved { get; set; }
    }

}
