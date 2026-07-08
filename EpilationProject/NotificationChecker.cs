using System;
using System.Collections.Generic;
using System.Linq;

namespace EpilationProject
{
    public class NotificationChecker
    {
        public List<Client> GetUpcomingProcedures(List<Client> clients, int daysAhead = 15)
        {
            return clients.Where(c => ProcedureScheduler.IsNextProcedureUpcoming(c, daysAhead))
                .OrderBy(c => ProcedureScheduler.CalculateNextProcedureDate(c.DateOfFirstProcedure, c.ProcedureCount, c.Service))
                .ToList();
        }

        public bool HasUpcomingProcedures(List<Client> clients, int daysAhead = 15)
        {
            return GetUpcomingProcedures(clients, daysAhead).Count > 0;
        }

        public string GetUpcomingProceduresSummary(List<Client> clients, int daysAhead = 15)
        {
            var upcomingClients = GetUpcomingProcedures(clients, daysAhead);
            if (upcomingClients.Count == 0)
                return $"No upcoming procedures in the next {daysAhead} days.";

            string summary = $"Upcoming procedures in the next {daysAhead} days:\n\n";
            foreach (var client in upcomingClients)
            {
                DateTime nextProcedureDate = ProcedureScheduler.CalculateNextProcedureDate(
                    client.DateOfFirstProcedure, 
                    client.ProcedureCount, 
                    client.Service
                );
                int nextProcedureNumber = client.ProcedureCount + 1;
                summary += $"• {client.Name} - Procedure #{nextProcedureNumber} on {nextProcedureDate:MMMM dd, yyyy} ({client.Service})\n";
            }
            return summary;
        }
    }
}
