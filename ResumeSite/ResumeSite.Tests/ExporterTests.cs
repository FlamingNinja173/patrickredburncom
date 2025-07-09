using ResumeSite.Export;
using System.Data.SQLite;

namespace ResumeSite.Tests
{
    public class ExporterTests
    {
        [Fact]
        public void Export_CreatesJsonFile()
        {
            string dbPath = Path.GetTempFileName();
            string outputPath = Path.GetTempFileName();

            using (var conn = new SQLiteConnection($"Data Source={dbPath}"))
            {
                conn.Open();
                SetupDatabase(conn);
            }

            Exporter.Export(dbPath, outputPath);

            Assert.True(File.Exists(outputPath));
            string json = File.ReadAllText(outputPath);
            Assert.Contains("Skills", json);
            Assert.Contains("Certifications", json);
            Assert.Contains("WorkHistory", json);
        }

        private static void SetupDatabase(SQLiteConnection conn)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE Skill (Id INTEGER PRIMARY KEY, Name TEXT, Description TEXT, Proficiency INTEGER);
                                INSERT INTO Skill (Name, Description, Proficiency) VALUES ('C#', 'Dotnet language', 4);
                                CREATE TABLE Certification (Id INTEGER PRIMARY KEY, Name TEXT, Issuer TEXT, DateEarned TEXT, Description TEXT);
                                INSERT INTO Certification (Name, Issuer, DateEarned, Description) VALUES ('Cert', 'Issuer', '2024-01-01', 'Desc');
                                CREATE TABLE WorkHistory (Id INTEGER PRIMARY KEY, CompanyName TEXT, JobTitle TEXT, StartDate TEXT, EndDate TEXT, Description TEXT);
                                INSERT INTO WorkHistory (CompanyName, JobTitle, StartDate, EndDate, Description) VALUES ('Comp', 'Dev', '2023-01-01', NULL, 'Desc');
                                CREATE TABLE WorkHistoryResponsibilities (WorkHistoryId INTEGER, Responsibility TEXT);
                                INSERT INTO WorkHistoryResponsibilities (WorkHistoryId, Responsibility) VALUES (1, 'Did stuff');";
            cmd.ExecuteNonQuery();
        }
    }
}
