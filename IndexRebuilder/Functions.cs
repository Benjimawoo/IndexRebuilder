using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Configuration;
using System.Data.SqlClient;

namespace IndexRebuilder
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            //log.WriteLine(message);
        }

        public static async Task RebuildIndexes([TimerTrigger("30 2 * * *", RunOnStartup =true)] TimerInfo timer, TextWriter log)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<Task> indexTasks = new List<Task>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string indexCommandText = "";
            }
        }
    }
}
