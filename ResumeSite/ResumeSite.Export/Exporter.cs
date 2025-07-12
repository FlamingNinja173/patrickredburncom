using System.Data.SQLite;
using System.Text.Json;
using ResumeSite.Models;

namespace ResumeSite.Export
{
    /// <summary>
    /// Handles exporting resume related tables from SQLite to JSON.
    /// </summary>
    public static class Exporter
    {
        /// <summary>
        /// Exports all resume data from the provided SQLite database to a JSON file.
        /// </summary>
        /// <param name="dbPath">Path to the SQLite database.</param>
        /// <param name="outputPath">Destination file for the JSON output.</param>
        public static void Export(string dbPath, string outputPath)
        {
            string connectionString = $"Data Source={dbPath}";
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();

            var retVal = new
            {
                Skills = GetSkills(conn),
                Certifications = GetCertifications(conn),
                WorkHistory = GetWorkHistory(conn),
                Education = GetEducation(conn)
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(retVal, options);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            File.WriteAllText(outputPath, json);
        }

        private static List<eSkill> GetSkills(SQLiteConnection conn)
        {
            var retVal = new List<eSkill>();
            using var cmd = new SQLiteCommand("SELECT Id, Name, Description, Proficiency FROM Skill", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var skill = new eSkill
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Proficiency = (Constants.SkillProficiency)reader.GetInt32(3)
                };
                retVal.Add(skill);
            }

            return retVal;
        }

        private static List<eCertification> GetCertifications(SQLiteConnection conn)
        {
            var retVal = new List<eCertification>();
            using var cmd = new SQLiteCommand("SELECT Id, Name, Issuer, DateEarned, Description, ImageUrl, CredentialUrl FROM Certification", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var cert = new eCertification
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Issuer = reader.GetString(2),
                    DateEarned = DateOnly.FromDateTime(reader.GetDateTime(3)),
                    Description = reader.IsDBNull(4) ? null : reader.GetString(4),
                    ImageUrl = reader.IsDBNull(5) ? null : reader.GetString(5),
                    CredentialUrl = reader.IsDBNull(6) ? null : reader.GetString(6)
                };
                retVal.Add(cert);
            }

            return retVal;
        }

        private static List<eWorkHistory> GetWorkHistory(SQLiteConnection conn)
        {
            var retVal = new List<eWorkHistory>();
            using var cmd = new SQLiteCommand("SELECT Id, CompanyName, JobTitle, StartDate, EndDate, Description FROM WorkHistory", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var work = new eWorkHistory
                {
                    Id = reader.GetInt32(0),
                    CompanyName = reader.GetString(1),
                    JobTitle = reader.GetString(2),
                    StartDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
                    EndDate = reader.IsDBNull(4) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(4)),
                    Description = reader.IsDBNull(5) ? null : reader.GetString(5)
                };
                retVal.Add(work);
            }

            foreach (var work in retVal)
            {
                using var cmdResp = new SQLiteCommand("SELECT Responsibility FROM WorkHistoryResponsibilities WHERE WorkHistoryId = @id", conn);
                cmdResp.Parameters.AddWithValue("@id", work.Id);
                using var readerResp = cmdResp.ExecuteReader();
                while (readerResp.Read())
                {
                    work.Responsibilities.Add(readerResp.GetString(0));
                }
            }

            return retVal;
        }

        private static List<eEducation> GetEducation(SQLiteConnection conn)
        {
            var retVal = new List<eEducation>();
            using var cmd = new SQLiteCommand("SELECT Id, School, Degree, StartDate, EndDate FROM Education", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var edu = new eEducation
                {
                    Id = reader.GetInt32(0),
                    School = reader.GetString(1),
                    Degree = reader.GetString(2),
                    StartDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
                    EndDate = reader.IsDBNull(4) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(4))
                };
                retVal.Add(edu);
            }

            return retVal;
        }
    }
}