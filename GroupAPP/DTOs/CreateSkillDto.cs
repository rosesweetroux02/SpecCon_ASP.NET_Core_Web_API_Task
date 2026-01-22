namespace GroupAPP.DTOs
{
    public class CreateSkillDto
    {
        public required string SkillName { get; set; }
        public required string CorrectedSkillName { get; set; }
        public int ProficiencyLevelId { get; set; }
    }
}
