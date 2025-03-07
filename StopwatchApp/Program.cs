using System;
using System.Windows.Forms;

namespace StopwatchApp  // ✅ Ensure this matches `MainForm.cs`
{
    static class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // ✅ Ensure MainForm is recognized
        }
    }
}
