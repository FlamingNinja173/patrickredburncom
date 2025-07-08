using static ResumeSite.Constants.Constants;

namespace ResumeSite.Models
{
    public class Skill : eBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public SkillProficiency Proficiency { get; set; }
    }
}
