using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdoConnectionSqlWithParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter Employee ID: ");
            int EmId = int.Parse(Console.ReadLine()); 

            string connectionString = "Server = (LocalDB)\\MSSQLLocalDB; Initial Catalog = MYDB; Integrated Security = true";

            string query = "select * from EMPLOYEES where ID = @EmId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmId", EmId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID {reader.GetInt32(0)} Name {reader.GetString(1)} Age {reader.GetByte(2)}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
