using System.Globalization;

namespace MusicManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set UI culture and culture to English (United States)
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}