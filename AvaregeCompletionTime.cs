using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairRequests
{
    public class TimeCalculation
    {
        public TimeCalculation() { }
        public double CalculateAverageCompletionTime()
        {
            double averageTime = 0;

            string connectionString = Program.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //вычисляем разницу между началом и завершением заявки
                string query = @"
                SELECT DATEDIFF(DAY, startDate, completionDate) AS CompletionTime
                FROM requests
                WHERE completionDate IS NOT NULL";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                var completionTimes = new List<int>();

                while (reader.Read())
                {
                    int completionTime = reader.GetInt32(0);
                    completionTimes.Add(completionTime);
                }

                //вычисляем среднее значение срока выполнения заявок
                if (completionTimes.Any())
                {
                    averageTime = completionTimes.Average();
                }
            }

            return averageTime;
        }
    }
}