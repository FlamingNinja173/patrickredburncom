using static ResumeSite.Constants;

namespace ResumeSite.Models
{
    public class eSkill : eBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public SkillProficiency Proficiency { get; set; }
    }
}
