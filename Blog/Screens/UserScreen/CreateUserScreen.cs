using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreen
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Usuario");
            Create();
        }
        
        private static void Create()
        {
            var user = new User();
            Console.Write("Nome: ");
            user.Name = Console.ReadLine();
            Console.Write("E-mail: ");
            user.Email = Console.ReadLine();
            Console.Write("Senha: ");
            user.PasswordHash = Console.ReadLine();
            Console.Write("Bio: ");
            user.Bio = Console.ReadLine();
            Console.Write("Caminho Image: ");
            user.Image = Console.ReadLine();
            Console.Write("Slug: ");
            user.Slug = Console.ReadLine();

            if (!user.Name.Equals("") && !user.Email.Equals("") && !user.PasswordHash.Equals("") && 
                !user.Bio.Equals("") && !user.Image.Equals("") && !user.Slug.Equals(""))
            {
                var repository = new Repository<User>(Database.Connection);
                var result = repository.Create(user);
                if (result != null)
                {
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    Thread.Sleep(200);
                    MenuUserScreen.Load();
                }
                Load();
            }

        }
    }
}