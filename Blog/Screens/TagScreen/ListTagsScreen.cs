using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreen
{
    public static class ListTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Tags");
            List();
            Console.WriteLine("-----------");

            Console.WriteLine("Voltar para Gerenciamento de Tags (s - Sim)");
            
            try
            {
                switch (Convert.ToChar(Console.ReadLine().ToLower()))
                {
                    case 's':
                        MenuTagScreen.Load();
                        break;
                    default:
                        MenuTagScreen.Load();
                        break;
                }
            } catch (FormatException error)
            {
                MenuTagScreen.Load();
            }
        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);

            foreach (var item in repository.Get())
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}