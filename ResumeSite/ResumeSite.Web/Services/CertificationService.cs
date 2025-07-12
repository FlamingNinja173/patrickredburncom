using ResumeSite.Models;
using System.Net.Http.Json;

namespace ResumeSite.Web.Services
{
    public class CertificationService(HttpClient http) : ICertificationService
    {
        private readonly HttpClient http = http;

        public async Task<List<eCertification>> GetCertifications()
        {
            var retVal = await http.GetFromJsonAsync<List<eCertification>>("sample-data/certifications.json");
            return retVal ?? [];
        }
    }
}
