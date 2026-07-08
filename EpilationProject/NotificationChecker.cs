using System;
using System.Collections.Generic;
using System.Linq;

namespace EpilationProject
{
    public class NotificationChecker
    {
        public List<Client> GetUpcomingProcedures(List<Client> clients, int daysAhead = 15)
        {
            DateTime today = DateTime.Now.Date;
            DateTime futureDate = today.AddDays(daysAhead);

            return clients.Where(c => 
                c.DateOfFirstProcedure >= today && 
                c.DateOfFirstProcedure <= futureDate
            ).OrderBy(c => c.DateOfFirstProcedure).ToList();
        }

        public bool HasUpcomingProcedures(List<Client> clients, int daysAhead = 15)
        {
            return GetUpcomingProcedures(clients, daysAhead).Count > 0;
        }

        public string GetUpcomingProceduresSummary(List<Client> clients, int daysAhead = 15)
        {
            var upcomingClients = GetUpcomingProcedures(clients, daysAhead);
            if (upcomingClients.Count == 0)
                return "No upcoming procedures in the next 15 days.";

            string summary = $"Upcoming procedures in the next {daysAhead} days:\n\n";
            foreach (var client in upcomingClients)
            {
                summary += $"• {client.Name} - {client.DateOfFirstProcedure:MMMM dd, yyyy} ({client.Service})\n";
            }
            return summary;
        }
    }
}
