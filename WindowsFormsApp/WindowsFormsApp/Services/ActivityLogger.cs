
using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp.Services
{
    internal class ActivityLogger
    {
        private static List<string> activities =
            new List<string>();

        // Record an activity
        public static void LogActivity(string description)
        {
            string activity =
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                + " - " + description;

            activities.Add(activity);
        }

        // Retrieve the latest activities
        public static List<string> GetRecentActivities()
        {
            return activities
                .TakeLast(10)
                .Reverse()
                .ToList();
        }

        // Clear activity history
        public static void ClearActivities()
        {
            activities.Clear();
        }
    }
}
