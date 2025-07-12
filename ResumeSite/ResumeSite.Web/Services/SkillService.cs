using ResumeSite.Models;
using System.Net.Http.Json;

namespace ResumeSite.Web.Services
{
    /// <summary>
    /// Service for retrieving skills.
    /// </summary>
    public class SkillService(HttpClient http) : ISkillService
    {
        private readonly HttpClient http = http;

        /// <inheritdoc />
        public async Task<List<eSkill>> GetSkills()
        {
            var retVal = await http.GetFromJsonAsync<List<eSkill>>("sample-data/skills.json");
            return retVal ?? [];
        }
    }
}