namespace ResumeSite.Models
{
    /// <summary>
    /// Represents a record of  work history, including details about the company, job title, employment dates, and responsibilities.
    /// </summary>
    public class eWorkHistory : eBase
    {
        /// <summary>
        /// The name of the company.
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// The job title associated with the work history.
        /// </summary>
        public string JobTitle { get; set; } = string.Empty;

        /// <summary>
        /// Start date of the Job.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// End Date of the Job. Nullable for current jobs.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Description of the job.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// List of responsibilities or achievements.
        /// </summary>
        public List<string> Responsibilities { get; set; } = new();

        /// <summary>
        /// Indicates if this is a current job.
        /// </summary>
        public bool IsCurrentJob => !EndDate.HasValue;
    }
}
