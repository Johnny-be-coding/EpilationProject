using System;
using System.IO;
using System.Windows.Forms;

namespace EpilationProject
{
    public class Settings
    {
        public string EpilationPersonEmail { get; set; }
        public string EpilationPersonName { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }

        public Settings()
        {
            EpilationPersonEmail = "";
            EpilationPersonName = "";
            SmtpServer = "smtp.gmail.com";
            SmtpPort = 587;
            SmtpUsername = "";
            SmtpPassword = "";
        }
    }

    public class SettingsManager
    {
        private string settingsFilePath;

        public SettingsManager()
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EpilationProject");
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
            settingsFilePath = Path.Combine(appDataPath, "settings.txt");
        }

        public Settings LoadSettings()
        {
            Settings settings = new Settings();

            if (!File.Exists(settingsFilePath))
            {
                return settings;
            }

            try
            {
                var lines = File.ReadAllLines(settingsFilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || !line.Contains("="))
                        continue;

                    var parts = line.Split('=');
                    if (parts.Length != 2)
                        continue;

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "EpilationPersonEmail":
                            settings.EpilationPersonEmail = value;
                            break;
                        case "EpilationPersonName":
                            settings.EpilationPersonName = value;
                            break;
                        case "SmtpServer":
                            settings.SmtpServer = value;
                            break;
                        case "SmtpPort":
                            if (int.TryParse(value, out int port))
                                settings.SmtpPort = port;
                            break;
                        case "SmtpUsername":
                            settings.SmtpUsername = value;
                            break;
                        case "SmtpPassword":
                            settings.SmtpPassword = value;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}");
            }

            return settings;
        }

        public void SaveSettings(Settings settings)
        {
            try
            {
                string[] lines = new string[]
                {
                    $"EpilationPersonEmail={settings.EpilationPersonEmail}",
                    $"EpilationPersonName={settings.EpilationPersonName}",
                    $"SmtpServer={settings.SmtpServer}",
                    $"SmtpPort={settings.SmtpPort}",
                    $"SmtpUsername={settings.SmtpUsername}",
                    $"SmtpPassword={settings.SmtpPassword}"
                };
                File.WriteAllLines(settingsFilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }
    }
}
