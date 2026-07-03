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
                string.IsNullOrWhiteSpace(txtService.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nextId = dataManager.GetNextId(clients);
            Client newClient = new Client(nextId, txtName.Text, txtPhone.Text, txtService.Text);
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
                string.IsNullOrWhiteSpace(txtService.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = listBoxClients.SelectedIndex;
            Client clientToUpdate = clients[selectedIndex];

            clientToUpdate.Name = txtName.Text;
            clientToUpdate.Phone = txtPhone.Text;
            clientToUpdate.Service = txtService.Text;

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
                txtService.Text = selectedClient.Service;
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtService.Clear();
            listBoxClients.SelectedIndex = -1;
        }
    }
}
