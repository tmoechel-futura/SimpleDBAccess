// See https://aka.ms/new-console-template for more information

using EFC6.Ch2.FitnessApp.Domain;
using Microsoft.Data.SqlClient;

List<RunActivity> runActivities = new List<RunActivity>();

ReadRunActivitiesFromDb();
ShowRunActivities();
void ReadRunActivitiesFromDb()
{
    string connectionString = @"Server = localhost\SQLEXPRESS; Database=FitnessDb; Trusted_Connection = True; TrustServerCertificate=True";

    var sqlConnection = new SqlConnection(connectionString);

    string sql = "select Id, Name, Distance from RunActivities";

    sqlConnection.Open();

    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var runActivity = new RunActivity() { Id = reader.GetInt32(0), Name = reader.GetString(1), Distance = reader.GetDouble(2) };
                runActivities.Add(runActivity);
            }
        }
    }
}

void ShowRunActivities()
{
    foreach (var runActivity in runActivities)
    {
        Console.WriteLine($"Name: {runActivity.Name} Distance: {runActivity.Distance}");
    }
}



