namespace ResumeSite.Models
{
    public class eResume : eBase
    {
        public string FullName { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public List<eSkill> Skills { get; set; } = new();
        public List<eCertification> Certifications { get; set; } = new();
        public List<eWorkHistory> WorkHistory { get; set; } = new();
    }
}
