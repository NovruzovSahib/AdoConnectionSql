using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Server =(LocalDB)\\MSSQLLocalDB; Initial Catalog = MYDB; Integrated Security = true";

        string query = "SELECT NAME from EMPLOYEES where ID = 2";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand sqlcommand = new SqlCommand(query, connection))
            {
                var reader = sqlcommand.ExecuteScalar();
                string Name = Convert.ToString(reader);
                Console.WriteLine($"Name is: {Name}");
            }
        }

        Console.ReadLine();
    }
}