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
            connection.Open();

            // ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
            ReadUsers(connection);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection).GetAll();
            foreach(var user in userRepository)
                Console.WriteLine(user);
        }
        
        // public static void ReadUser()
        // {
        //     Console.Clear();

        //     using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(1);
        //         Console.WriteLine(user);
        //     }
        // }

        // public static void CreateUser()
        // {
        //     User user = new User() {
        //         Name = "Jão Silva",
        //         Email = "jao@email.com",
        //         Bio = "EStudante de Programação",
        //         Image = "https://caminho_da_imagem",
        //         Slug = "jao",
        //         PasswordHash = "asdf"

        //     };
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Insert<User>(user);
        //         Console.WriteLine($"Cadastro realizado com sucesso!");
        //     }
        // }

        // public static void UpdateUser()
        // {
        //     User user = new User() {
        //         Id = 4,
        //         Name = "Jão da Silva",
        //         Email = "jao@email.com",
        //         Bio = "Estudante de Programação",
        //         Image = "https://caminho_da_imagem",
        //         Slug = "jao",
        //         PasswordHash = "asf"

        //     };
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Update<User>(new User() {
        //             Id = 4,
        //             Name = "Jão da Silva",
        //             Email = "jao@email.com",
        //             Bio = "Estudante de Programação",
        //             Image = "https://caminho_da_imagem",
        //             Slug = "jao",
        //             PasswordHash = "asf"

        //         });
        //         Console.WriteLine("Cadatro atualizado com sucesso!");
        //     }
        // }

        // public static void DeleteUser()
        // {
        //     using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(2);
        //         connection.Delete<User>(user);
        //         Console.WriteLine("Usuário deletado com sucesso!");
        //     }
        // }

    }
}