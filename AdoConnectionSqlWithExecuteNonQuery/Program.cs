using System.Data.SqlClient;
internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Server = (LocalDB)\\MSSQLLocalDB; Initial Catalog = MYDB; Integrated Security = true";

        string query = "Insert into Employees values('Aysen',26)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                int res = command.ExecuteNonQuery();
                Console.WriteLine($"Operation result is {res}");
            }
        }

        Console.ReadLine();
    }
}