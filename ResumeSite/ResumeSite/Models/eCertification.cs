namespace ResumeSite.Models
{
    public class eCertification : eBase
    {
        public string Name { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public DateOnly DateEarned { get; set; }
        public string? Description { get; set; }
    }
}
