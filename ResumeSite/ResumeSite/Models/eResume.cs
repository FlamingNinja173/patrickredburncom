namespace ResumeSite.Models
{
    public class Resume : eBase
    {
        public string FullName { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public List<Skill> Skills { get; set; } = new();
        public List<Certification> Certifications { get; set; } = new();
    }
}
