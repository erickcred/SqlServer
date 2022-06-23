using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreen
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Perfis");
            List();
            Console.WriteLine("-----------");

            Console.WriteLine("Voltar para Gerenciamento de Roles (s - Sim)");
            
            try
            {
                switch (Convert.ToChar(Console.ReadLine().ToLower()))
                {
                    case 's':
                        MenuRoleScreen.Load();
                        break;
                    default:
                        MenuRoleScreen.Load();
                        break;
                }
            } catch (FormatException error)
            {
                MenuRoleScreen.Load();
            }
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.Connection);

            foreach (var role in repository.Get())
                Console.WriteLine($"{role.Id} - {role.Name}");
        }
    }
}