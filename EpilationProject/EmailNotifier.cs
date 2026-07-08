using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EpilationProject
{
    public class EmailNotifier
    {
        private Settings settings;

        public EmailNotifier(Settings settings)
        {
            this.settings = settings;
        }

        public bool SendNotificationEmail(Client client)
        {
            if (string.IsNullOrWhiteSpace(settings.EpilationPersonEmail))
            {
                MessageBox.Show("Email settings not configured. Please set up your email in Settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(settings.SmtpServer, settings.SmtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(settings.SmtpUsername, settings.SmtpPassword);

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(settings.SmtpUsername);
                        mailMessage.To.Add(settings.EpilationPersonEmail);
                        mailMessage.Subject = $"Epilation Appointment Reminder - {client.Name}";
                        mailMessage.IsBodyHtml = true;

                        string procedureDate = client.DateOfFirstProcedure.ToString("MMMM dd, yyyy");
                        string bodyText = $@"
                            <h2>Epilation Appointment Reminder</h2>
                            <p>Dear {settings.EpilationPersonName},</p>
                            <p>This is a reminder that client <strong>{client.Name}</strong> has an epilation appointment scheduled in approximately 15 days.</p>
                            <table border='1' style='border-collapse: collapse; margin: 20px 0;'>
                                <tr>
                                    <td style='padding: 8px;'><strong>Client Name:</strong></td>
                                    <td style='padding: 8px;'>{client.Name}</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px;'><strong>Phone:</strong></td>
                                    <td style='padding: 8px;'>{client.Phone}</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px;'><strong>Service:</strong></td>
                                    <td style='padding: 8px;'>{client.Service}</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px;'><strong>Scheduled Date:</strong></td>
                                    <td style='padding: 8px;'>{procedureDate}</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px;'><strong>Energy:</strong></td>
                                    <td style='padding: 8px;'>{client.Energy} J m/s</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px;'><strong>Phototype:</strong></td>
                                    <td style='padding: 8px;'>{client.Phototype}</td>
                                </tr>
                            </table>
                            <p>Please ensure you are prepared for this appointment.</p>
                            <p>Best regards,<br />Epilation Project System</p>";

                        mailMessage.Body = bodyText;

                        smtpClient.Send(mailMessage);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void SendAllUpcomingReminders(System.Collections.Generic.List<Client> clients)
        {
            int notificationCount = 0;
            foreach (var client in clients)
            {
                if (IsUpcomingProcedure(client.DateOfFirstProcedure))
                {
                    if (SendNotificationEmail(client))
                    {
                        notificationCount++;
                    }
                }
            }

            if (notificationCount > 0)
            {
                MessageBox.Show($"Successfully sent {notificationCount} notification email(s).", "Notifications Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsUpcomingProcedure(DateTime procedureDate)
        {
            DateTime today = DateTime.Now.Date;
            DateTime fifteenDaysFromNow = today.AddDays(15);
            return procedureDate >= today && procedureDate <= fifteenDaysFromNow;
        }
    }
}
