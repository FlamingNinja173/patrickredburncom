using ResumeSite.Models;

namespace ResumeSite.Web.Services
{
    /// <summary>
    /// Provides access to skill data.
    /// </summary>
    public interface ISkillService
    {
        /// <summary>
        /// Retrieves skills from the backend.
        /// </summary>
        /// <returns>A list of <see cref="eSkill"/> objects.</returns>
        Task<List<eSkill>> GetSkills();
    }
}