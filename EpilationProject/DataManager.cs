using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EpilationProject
{
    public class DataManager
    {
        private string dataFilePath;

        public DataManager()
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EpilationProject");
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
            dataFilePath = Path.Combine(appDataPath, "data.csv");
        }

        public List<Client> LoadClients()
        {
            List<Client> clients = new List<Client>();

            if (!File.Exists(dataFilePath))
            {
                return clients;
            }

            try
            {
                var lines = File.ReadAllLines(dataFilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var parts = line.Split('|');
                    if (parts.Length >= 4 && int.TryParse(parts[0], out int id))
                    {
                        string energy = parts.Length > 4 ? parts[4] : "";
                        string phototype = parts.Length > 5 ? parts[5] : "";
                        DateTime dateOfFirstProcedure = DateTime.MinValue;
                        if (parts.Length > 6 && DateTime.TryParse(parts[6], out DateTime date))
                        {
                            dateOfFirstProcedure = date;
                        }
                        int procedureCount = 0;
                        if (parts.Length > 7 && int.TryParse(parts[7], out int count))
                        {
                            procedureCount = count;
                        }
                        clients.Add(new Client(id, parts[1], parts[2], parts[3], energy, phototype, dateOfFirstProcedure, procedureCount));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading data: {ex.Message}");
            }

            return clients;
        }

        public void SaveClients(List<Client> clients)
        {
            try
            {
                var lines = clients.Select(c => $"{c.Id}|{c.Name}|{c.Phone}|{c.Service}|{c.Energy}|{c.Phototype}|{c.DateOfFirstProcedure:yyyy-MM-dd}|{c.ProcedureCount}").ToArray();
                File.WriteAllLines(dataFilePath, lines);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }

        public int GetNextId(List<Client> clients)
        {
            return clients.Count > 0 ? clients.Max(c => c.Id) + 1 : 1;
        }
    }
}
