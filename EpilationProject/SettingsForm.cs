using System;
using System.Windows.Forms;

namespace EpilationProject
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        private SettingsManager settingsManager;

        public SettingsForm()
        {
            InitializeComponent();
            settingsManager = new SettingsManager();
            settings = settingsManager.LoadSettings();
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtEmail.Text = settings.EpilationPersonEmail;
            txtName.Text = settings.EpilationPersonName;
            txtSmtpServer.Text = settings.SmtpServer;
            txtSmtpPort.Text = settings.SmtpPort.ToString();
            txtSmtpUsername.Text = settings.SmtpUsername;
            txtSmtpPassword.Text = settings.SmtpPassword;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSmtpPort.Text, out int port) || port <= 0)
            {
                MessageBox.Show("Please enter a valid SMTP port number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            settings.EpilationPersonEmail = txtEmail.Text;
            settings.EpilationPersonName = txtName.Text;
            settings.SmtpServer = txtSmtpServer.Text;
            settings.SmtpPort = port;
            settings.SmtpUsername = txtSmtpUsername.Text;
            settings.SmtpPassword = txtSmtpPassword.Text;

            settingsManager.SaveSettings(settings);
            MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
