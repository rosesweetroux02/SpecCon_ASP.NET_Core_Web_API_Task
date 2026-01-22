namespace GroupAPP.DTOs
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string CorrectedSkillName { get; set; }
        public int ProficiencyLevelId { get; set; }
        public bool IsApproved { get; set; }
    }

}
