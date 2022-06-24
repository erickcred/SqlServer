using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Categoria");
            Create();
            Console.WriteLine("-----------");

            Console.WriteLine("Voltar para Gerenciamento de Categorias (s - Sim)");
            
            try
            {
                switch (Convert.ToChar(Console.ReadLine().ToLower()))
                {
                    case 's':
                        MenuCategoryScreen.Load();
                        break;
                    default:
                        MenuCategoryScreen.Load();
                        break;
                }
            } catch (FormatException error)
            {
                MenuCategoryScreen.Load();
            }
        }

        private static void Create()
        {
            try
            {
                var repository =  new Repository<Category>(Database.Connection);

                var category = new Category();
                Console.Write("Nome: ");
                category.Name = Console.ReadLine();
                Console.Write("Slug: ");
                category.Slug = Console.ReadLine();

                repository.Create(category);
                Console.WriteLine($"Categoria {category.Name} adicionada com sucesso!");
                Thread.Sleep(2000);
                MenuCategoryScreen.Load();
            } catch (Exception erro)
            {
                Console.WriteLine(erro);
                Thread.Sleep(4000);
                Load();
            }
        }
    }
}