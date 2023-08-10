using System;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MYDB;Integrated Security=true";
        string query = "Select * from EMPLOYEES";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID {reader.GetInt32(0)} Name: {reader.GetString(1)} Age: {reader.GetByte(2)}");
                }

            }

        }

    }
}



