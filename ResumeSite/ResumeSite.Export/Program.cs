namespace ResumeSite.Export
{
    /// <summary>
    /// Entry point for the export utility.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Executes the export process.
        /// </summary>
        /// <param name="args">Command line arguments. The first is the SQLite database path and the second is the output JSON path.</param>
        static void Main(string[] args)
        {
            string dbPath = args.Length > 0 ? args[0] : "resume.db";
            string outputPath = args.Length > 1 ? args[1] : Path.Combine("..", "ResumeSite", "wwwroot", "data", "resume.json");

            Exporter.Export(dbPath, outputPath);
        }
    }
}