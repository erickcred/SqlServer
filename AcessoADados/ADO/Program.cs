using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string connectionString = @"Data Source=localhost\SQLEXPRESS;Database=erickcred;TrustServerCertificate=true;User ID=sa;Password=123;";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
                
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}")   ;
                    }
                }
                connection.Close();
            }
        }
    }
}