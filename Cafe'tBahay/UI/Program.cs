namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Create a standard Form, add your UserControl to it, and run it
            Form mainForm = new Form();
            mainForm.Text = "User Role Management Test";
            mainForm.Width = 800;
            mainForm.Height = 600;

            ucUserRole myUserControl = new ucUserRole();
            myUserControl.Dock = DockStyle.Fill; // Fill the whole form
            mainForm.Controls.Add(myUserControl);

            Application.Run(mainForm);
        }
    }
}