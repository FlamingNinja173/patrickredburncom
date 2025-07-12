using ResumeSite.Models;

namespace ResumeSite.Web.Services
{
    /// <summary>
    /// Provides access to education data.
    /// </summary>
    public interface IEducationService
    {
        /// <summary>
        /// Retrieves education records from the backend.
        /// </summary>
        /// <returns>A list of <see cref="eEducation"/> objects.</returns>
        Task<List<eEducation>> GetEducation();
    }
}