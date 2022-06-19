using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Repositories;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = 
        @"Data Source=localhost\SQLEXPRESS;Database=Blog;TrustServerCertificate=true;User ID=sa;Password=123";
        
        public static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            Console.Clear();
            connection.Open();

            ReadUsers(connection);
            Console.WriteLine();
            // ReadRoles(connection);
            // DeleteUser(connection);
            UpdateUser(connection);
            ReadUsers(connection);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetAll();
            
            foreach (var user in users)
                Console.WriteLine(user);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var user = connection.Get<User>(9);
            user.Email = "jessicad@email.com";

            var respository = new UserRepository(connection);
            respository.Update(user);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            repository.Delete(10);
        }
        
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.GetAll();

            foreach (Role role in roles)
            {
                Console.WriteLine(role);
            }
        }

    }
}