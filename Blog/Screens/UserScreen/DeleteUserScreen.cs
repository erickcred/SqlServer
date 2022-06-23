using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreen
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar usuário!");
            Delete();
        }

        private static void Delete()
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                foreach (var u in repository.Get())
                    Console.WriteLine($"{u.Id} - {u.Name}");

                Console.Write("Número do usuário a ser deleteado: ");
                repository.Delete(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Usuário deletado com sucesso!");
                Thread.Sleep(2000);
                MenuUserScreen.Load();
            } catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
        }
    }
}