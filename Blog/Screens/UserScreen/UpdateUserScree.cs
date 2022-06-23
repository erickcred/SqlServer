using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreen
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando Usuário");
            UpdateUser();
        }

        private static void UpdateUser()
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);

                foreach (var u in repository.Get())
                    Console.WriteLine($"{u.Id} -  {u.Name}, {u.Email}, {u.Image}, {u.Slug}");
                Console.WriteLine("Selecione o usuário para atualizar!");

                var user = new User();
                Console.Write("Número do usuário: ");
                user.Id = Convert.ToInt32(Console.ReadLine());
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

                repository.Update(user);

                Console.WriteLine("Usuário atualizado com sucesso!");
                Thread.Sleep(2000);
                MenuUserScreen.Load();
            } catch (Exception erro)
            {
                Console.WriteLine(erro);
                Thread.Sleep(4000);
                Load();
            }


        }
    }
}