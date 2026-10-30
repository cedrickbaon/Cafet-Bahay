using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public sealed class SetupAccountsForm : Form
    {
        public SetupAccountsForm()
        {
            Text = "One-time account setup";
            ClientSize = new Size(480, 380);

            StartPosition =
                FormStartPosition.CenterScreen;

            var layout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(20)
            };

            layout.Controls.Add(new Label
            {
                Text =
                    "Choose two different usernames.\n" +
                    "Existing matching accounts receive the new passwords.",
                AutoSize = true
            });

            TextBox admin = AddBox(
                layout, "Admin username", false);

            TextBox adminPassword = AddBox(
                layout,
                "New Admin password (8–128 characters)",
                true);

            TextBox cashier = AddBox(
                layout, "Cashier username", false);

            TextBox cashierPassword = AddBox(
                layout,
                "New Cashier password (8–128 characters)",
                true);

            var save = new Button
            {
                Text = "Create / configure accounts",
                AutoSize = true
            };

            save.Click += (sender, e) =>
            {
                save.Enabled = false;

                try
                {
                    AppServices.Users.InitializeFirstRun(
                        admin.Text,
                        adminPassword.Text,
                        cashier.Text,
                        cashierPassword.Text);

                    MessageBox.Show(
                        this,
                        "Accounts are ready. Restore NewLogin as the startup form.");

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this, ex.Message);
                }
                finally
                {
                    if (!save.IsDisposed)
                        save.Enabled = true;
                }
            };

            layout.Controls.Add(save);
            Controls.Add(layout);

            AcceptButton = save;
        }

        private static TextBox AddBox(
            Control layout,
            string caption,
            bool password)
        {
            layout.Controls.Add(new Label
            {
                Text = caption,
                AutoSize = true
            });

            var textbox = new TextBox
            {
                Width = 350,
                UseSystemPasswordChar = password,
                MaxLength = password ? 128 : 100
            };

            layout.Controls.Add(textbox);

            return textbox;
        }
    }
}