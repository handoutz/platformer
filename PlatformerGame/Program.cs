namespace PlatformerGame
{
    internal static class Program
    {
        public static Form1 MainForm { get; set; }
        public static Engine.Engine Engine => MainForm.Engine;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(MainForm=new Form1());
        }
    }
}