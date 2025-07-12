using ResumeSite.Models;
using System.Net.Http.Json;

namespace ResumeSite.Web.Services
{
    /// <summary>
    /// Service for retrieving education data.
    /// </summary>
    public class EducationService(HttpClient http) : IEducationService
    {
        private readonly HttpClient http = http;

        /// <inheritdoc />
        public async Task<List<eEducation>> GetEducation()
        {
            var retVal = await http.GetFromJsonAsync<List<eEducation>>("sample-data/education.json");
            return retVal ?? [];
        }
    }
}