using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreen
{
    public static class ListUserScreen
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
                        MenuUserScreen.Load();
                        break;
                    default:
                        MenuUserScreen.Load();
                        break;
                }
            } catch (FormatException error)
            {
                MenuUserScreen.Load();
            }
        }

        private static void List()
        {
            foreach (var item in new Repository<User>(Database.Connection).Get())
            {
                 Console.WriteLine($"{item.Id} - {item.Name}, {item.Email}");
            }
        }
    }
}