using ExpenseTrackerApp.Views;  // Add this to reference the Views folder where LoginForm is located

namespace ExpenseTrackerApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());  // Start the application with the LoginForm
        }
    }
}
