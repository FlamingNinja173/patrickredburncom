using ResumeSite.Models;

namespace ResumeSite.Web.Services
{
    public interface ICertificationService
    {
        Task<List<eCertification>> GetCertifications();
    }
}
