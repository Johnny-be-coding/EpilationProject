using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpilationProject
{
    public partial class Form1 : Form
    {
        private DataManager dataManager;
        private List<Client> clients;

        public Form1()
        {
            InitializeComponent();
            dataManager = new DataManager();
            clients = new List<Client>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            clients = dataManager.LoadClients();
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            listBoxClients.DataSource = null;
            listBoxClients.DataSource = new BindingSource(clients, null);
            listBoxClients.DisplayMember = null;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtPhone.Text) || 
                cmbService.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtProcedureCount.Text, out int procedureCount) || procedureCount < 0)
            {
                MessageBox.Show("Procedure Count must be a non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nextId = dataManager.GetNextId(clients);
            Client newClient = new Client(nextId, txtName.Text, txtPhone.Text, cmbService.SelectedItem.ToString(), txtEnergy.Text, txtPhototype.Text, dtpDateOfFirstProcedure.Value, procedureCount);
            clients.Add(newClient);
            dataManager.SaveClients(clients);

            ClearInputs();
            RefreshListBox();
            MessageBox.Show("Client added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a client first to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtPhone.Text) || 
                cmbService.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtProcedureCount.Text, out int procedureCount) || procedureCount < 0)
            {
                MessageBox.Show("Procedure Count must be a non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = listBoxClients.SelectedIndex;
            Client clientToUpdate = clients[selectedIndex];

            clientToUpdate.Name = txtName.Text;
            clientToUpdate.Phone = txtPhone.Text;
            clientToUpdate.Service = cmbService.SelectedItem.ToString();
            clientToUpdate.Energy = txtEnergy.Text;
            clientToUpdate.Phototype = txtPhototype.Text;
            clientToUpdate.DateOfFirstProcedure = dtpDateOfFirstProcedure.Value;
            clientToUpdate.ProcedureCount = procedureCount;

            dataManager.SaveClients(clients);
            RefreshListBox();
            listBoxClients.SelectedIndex = selectedIndex;

            MessageBox.Show("Client updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a client first to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int selectedIndex = listBoxClients.SelectedIndex;
                clients.RemoveAt(selectedIndex);
                dataManager.SaveClients(clients);

                ClearInputs();
                RefreshListBox();

                MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedIndex >= 0 && listBoxClients.SelectedIndex < clients.Count)
            {
                Client selectedClient = clients[listBoxClients.SelectedIndex];
                txtName.Text = selectedClient.Name;
                txtPhone.Text = selectedClient.Phone;
                cmbService.SelectedItem = selectedClient.Service;
                txtEnergy.Text = selectedClient.Energy;
                txtPhototype.Text = selectedClient.Phototype;
                txtProcedureCount.Text = selectedClient.ProcedureCount.ToString();

                // Ensure the date is within DateTimePicker's valid range
                DateTime date = selectedClient.DateOfFirstProcedure;
                if (date < dtpDateOfFirstProcedure.MinDate || date > dtpDateOfFirstProcedure.MaxDate)
                {
                    date = DateTime.Now;
                }
                dtpDateOfFirstProcedure.Value = date;
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
            cmbService.SelectedIndex = -1;
            txtEnergy.Clear();
            txtPhototype.Clear();
            txtProcedureCount.Clear();
            dtpDateOfFirstProcedure.Value = DateTime.Now;
            listBoxClients.SelectedIndex = -1;
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }

        private void BtnCheckNotifications_Click(object sender, EventArgs e)
        {
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.LoadSettings();

            if (string.IsNullOrWhiteSpace(settings.EpilationPersonEmail))
            {
                MessageBox.Show("Please configure your email in Settings first.", "Settings Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NotificationChecker checker = new NotificationChecker();
            var upcomingClients = checker.GetUpcomingProcedures(clients, 15);

            if (upcomingClients.Count == 0)
            {
                MessageBox.Show("No upcoming procedures in the next 15 days.", "No Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string summary = checker.GetUpcomingProceduresSummary(clients, 15);
            DialogResult result = MessageBox.Show(summary + "\n\nWould you like to send email notifications for these clients?", "Upcoming Procedures", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                EmailNotifier emailNotifier = new EmailNotifier(settings);
                emailNotifier.SendAllUpcomingReminders(upcomingClients);
            }
        }
    }
}
