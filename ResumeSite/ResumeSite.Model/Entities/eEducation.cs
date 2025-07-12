namespace ResumeSite.Models
{
    /// <summary>
    /// Represents an education record, including school, degree, and dates.
    /// </summary>
    public class eEducation : eBase
    {
        /// <summary>
        /// Name of the school or institution.
        /// </summary>
        public string School { get; set; } = string.Empty;

        /// <summary>
        /// Degree or program completed.
        /// </summary>
        public string Degree { get; set; } = string.Empty;

        /// <summary>
        /// Start date of the education period.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// End date of the education period.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Indicates if this is currently in progress.
        /// </summary>
        public bool IsInProgress => !EndDate.HasValue;
    }
}