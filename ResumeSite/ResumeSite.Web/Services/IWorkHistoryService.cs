using ResumeSite.Models;

namespace ResumeSite.Web.Services
{
    public interface IWorkHistoryService
    {
        public Task<List<eWorkHistory>> GetWorkHistory();
    }
}
