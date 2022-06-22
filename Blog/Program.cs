using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Repositories;
// using Blog.Views;
// using Blog.Views.Menus;
using Blog.Screens.UserScreen;
using Blog.Screens.RoleScreen;
using Blog.Screens.CategoryScreen;
using Blog.Screens.TagScreen;


namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = 
        @"Data Source=localhost\SQLEXPRESS;Database=Blog;TrustServerCertificate=true;User ID=sa;Password=123";
        
        public static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Console.Clear();
            Database.Connection.Open();

            Load();

            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();

            Console.WriteLine(
                "Blog\n" +
                "1 - Gerenciar Usuario\n" +
                "2 - Gerenciar Perfis\n" +
                "3 - Gerenciar Caegorias\n" +
                "4 - Gerenciar Tags\n" +
                "5 - Vincular Perfil a Usuário\n" +
                "6 - Vincular Post a Tag\n" +
                "7 - Relatórios" + 
                "\n-----------------------------"
            );

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    Load();
                    break;
            }
        }

        

        // public static void ReadUsers(SqlConnection connection)
        // {
        //     var repository = new Repository<User>(connection);
        //     var users = repository.Get();
        //     foreach (var item in users)
        //     {
        //         Console.WriteLine($"{item.Name}");
        //     }
        // }

        // public static void ReadUsersAndRoles(SqlConnection connection)
        // {
        //     var repository = new UserRepository(connection);
        //     var users = repository.GetWithRoles();
        //     foreach (var item in users)
        //     {
        //         Console.Write($"{item.Name} \n - Bio: {item.Bio}");
        //         foreach (var role in item.Roles)
        //         {
        //             Console.WriteLine($" - Role: {role.Name}");
        //         }
        //     }
        // }

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


        public static void ReadPosts(SqlConnection connection)
        {
            var repository = new Repository<Post>(connection);
            foreach (var item in repository.Get())
            {
                var nameCategory = new Repository<Category>(connection).GetById(item.CategoryId);
                var authorCategory = new Repository<User>(connection).GetById(item.AuthorId);

                Console.WriteLine($"Category: {nameCategory.Name}");
                Console.WriteLine($"Author: {authorCategory.Name}");
                Console.WriteLine($"Title Category: {item.Title}");
                Console.WriteLine(item.Body);
                Console.WriteLine($"Create Date: {item.CreateDate} \nUpdate Date: {item.LastUpdateDate}");
                
            }
        }

        public static void CreatePost(SqlConnection connection)
        {
            Repository<Post> repository = new Repository<Post>(connection);
            var post = repository.Create(new Post() {
                CategoryId = 2,
                AuthorId = 11,
                Title = "Evoluindo JavaScript manipulação do DOM",
                Summary = "Manipulando o DOM",
                Body = "Cupidatat dolore commodo anim adipisicing irure elit consequat qui sit exercitation velit. Enim ex consectetur ut sunt. Incididunt occaecat et commodo esse officia nostrud sit commodo reprehenderit cupidatat cupidatat et adipisicing. Sit ipsum adipisicing occaecat adipisicing incididunt laboris ex consequat amet aliquip qui cillum nostrud. Ipsum qui excepteur dolor aliquip ad sunt deserunt.",
                Slug = "manpulando-dom",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            });

            if (post.Id != 0)
            {
                Console.WriteLine("post criado com sucesso!");
            }
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