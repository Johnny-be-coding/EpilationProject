using System;

namespace EpilationProject
{
    public class ProcedureScheduler
    {
        // Service type constants
        public const string SERVICE_ЛИЦЕ = "Процедура ЛИЦЕ";
        public const string SERVICE_ТОРС = "Процедура ТОРС";
        public const string SERVICE_КРАКА = "Процедура КРАКА";

        /// <summary>
        /// Gets the interval in days for a specific procedure number and service type.
        /// Procedures 1-6 use the first interval, 7-8 use the second interval, 9+ use 365 days.
        /// </summary>
        public static int GetProcedureInterval(int procedureNumber, string service)
        {
            if (procedureNumber <= 0)
                return 0;

            // Procedures 1-6: use first interval
            if (procedureNumber <= 6)
            {
                return GetFirstInterval(service);
            }
            // Procedures 7-8: use second interval
            else if (procedureNumber <= 8)
            {
                return GetSecondInterval(service);
            }
            // Procedure 9+: yearly (365 days)
            else
            {
                return 365;
            }
        }

        /// <summary>
        /// Gets the first interval (procedures 1-6) for a given service.
        /// </summary>
        private static int GetFirstInterval(string service)
        {
            switch (service)
            {
                case SERVICE_ЛИЦЕ:
                    return 30;
                case SERVICE_ТОРС:
                    return 45;
                case SERVICE_КРАКА:
                    return 60;
                default:
                    return 30; // Default fallback
            }
        }

        /// <summary>
        /// Gets the second interval (procedures 7-8) for a given service.
        /// </summary>
        private static int GetSecondInterval(string service)
        {
            switch (service)
            {
                case SERVICE_ЛИЦЕ:
                    return 40;
                case SERVICE_ТОРС:
                    return 60;
                case SERVICE_КРАКА:
                    return 90;
                default:
                    return 40; // Default fallback
            }
        }

        /// <summary>
        /// Calculates the next procedure date based on:
        /// - dateOfFirstProcedure: The date of the 1st procedure
        /// - completedProcedureCount: How many procedures have been completed
        /// - service: The service type
        /// 
        /// Returns the date of the (completedProcedureCount + 1)th procedure.
        /// </summary>
        public static DateTime CalculateNextProcedureDate(DateTime dateOfFirstProcedure, int completedProcedureCount, string service)
        {
            // The next procedure number is completedProcedureCount + 1
            int nextProcedureNumber = completedProcedureCount + 1;

            // Start from the first procedure date
            DateTime currentDate = dateOfFirstProcedure;

            // Calculate date for each procedure up to the next one
            for (int i = 1; i < nextProcedureNumber; i++)
            {
                int daysToAdd = GetProcedureInterval(i, service);
                currentDate = currentDate.AddDays(daysToAdd);
            }

            return currentDate;
        }

        /// <summary>
        /// Checks if the next procedure for this client is upcoming (within daysAhead from today).
        /// </summary>
        public static bool IsNextProcedureUpcoming(Client client, int daysAhead = 15)
        {
            if (client.ProcedureCount < 0 || string.IsNullOrWhiteSpace(client.Service))
                return false;

            DateTime nextProcedureDate = CalculateNextProcedureDate(
                client.DateOfFirstProcedure,
                client.ProcedureCount,
                client.Service
            );

            DateTime today = DateTime.Now.Date;
            DateTime futureDate = today.AddDays(daysAhead);

            return nextProcedureDate >= today && nextProcedureDate <= futureDate;
        }

        /// <summary>
        /// Gets a friendly description of the next procedure for a client.
        /// </summary>
        public static string GetNextProcedureInfo(Client client)
        {
            if (client.ProcedureCount < 0 || string.IsNullOrWhiteSpace(client.Service))
                return "No procedure scheduled";

            int nextProcedureNumber = client.ProcedureCount + 1;
            DateTime nextProcedureDate = CalculateNextProcedureDate(
                client.DateOfFirstProcedure,
                client.ProcedureCount,
                client.Service
            );

            return $"Procedure #{nextProcedureNumber} on {nextProcedureDate:MMMM dd, yyyy}";
        }
    }
}
