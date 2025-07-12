using ResumeSite.Models;
using System.Net.Http.Json;

namespace ResumeSite.Web.Services
{
    public class WorkHistoryService(HttpClient http) : IWorkHistoryService
    {
        private readonly HttpClient http = http;

        public async Task<List<eWorkHistory>> GetWorkHistory()
        {
            var retVal = await http.GetFromJsonAsync<List<eWorkHistory>>("sample-data/workhistory.json");
            return retVal ?? [];
        }
    }
}