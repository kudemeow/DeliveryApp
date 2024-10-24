namespace Orders
{
    internal class Logging
    {
        public static void Log(string message)
        {
            string logFilePath = GetLogFilePath();

            try
            {
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        private static string GetLogFilePath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string logFileName = "delivery_log.txt";

            return Path.Combine(desktopPath, logFileName);
        }
    }
}
