using System.Runtime.InteropServices;

namespace Neuro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            AllocConsole();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}