using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Categorias:");
            Console.WriteLine("---------------");
            List();
            Console.WriteLine("Voltar para Gerenciamento de Roles (s - Sim)");

            try
            {
                switch (Convert.ToChar(Console.ReadLine()))
                {
                    case 's':
                        MenuCategoryScreen.Load();
                        break;
                    default:
                        MenuCategoryScreen.Load();
                        break;
                }
            } catch (Exception erro)
            {
                Console.WriteLine(erro);
                Thread.Sleep(4000);
                MenuCategoryScreen.Load();
            }
        }

        private static void List()
        {
            var repository = new Repository<Category>(Database.Connection);

            foreach (var category in repository.Get())
                Console.WriteLine($"{category.Id} - {category.Name}");
        }
    }
}