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

            Console.WriteLine("Users");
            ReadUsers(connection);

            Console.WriteLine("\nRoles");
            ReadRoles(connection);

            Console.WriteLine("\nTags");
            ReadTags(connection);

            Console.WriteLine("\nCategories");
            ReadCategories(connection);

            
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.Get();
            ReadItems(users);
        }

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            Console.WriteLine(repository.GetById(1));
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var user = connection.Get<User>(9);
            user.Email = "jessica@email.com.br";

            var respository = new Repository<User>(connection);
            respository.Update(user);
        }

        public static void DeleteUserId(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            repository.Delete(1);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.GetById(9);
            repository.Delete(user);
        }

        public static void CreateUser(SqlConnection connection)
        {
            var respository = new Repository<User>(connection);
            var user = respository.Create(new User() {
                Name = "Alfred Mord",
                Email = "alfbt@email.com",
                PasswordHash = "4321",
                Bio = "Mordomo",
                Image = "https://...",
                Slug = "alf"
            });
            Console.WriteLine($"Usuário ({user.Id} - {user.Name}) adicionado com sucesso!");
        }
        
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Get();

            foreach (var item in roles)
            {
                Console.WriteLine(item);
            }
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            ReadItems(repository.Get());
        }

        public static void ReadCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            ReadItems(repository.Get());
        }

        private static void ReadItems(IEnumerable<Object> obj)
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    
    
    }
}