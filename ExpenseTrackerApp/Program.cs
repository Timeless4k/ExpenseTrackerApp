using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Views;  // Make sure to reference Views where WelcomeForm is located

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

            // Start with WelcomeForm as the initial form
            
            Application.Run(new WelcomeForm());
        }
    }
}
