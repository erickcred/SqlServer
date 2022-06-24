using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualização de Categoria");
            Delete();
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

        private static void Delete()
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                foreach (var cat in repository.ReadCategoryAndQuantityPost())
                    Console.WriteLine($"{cat.Id} - {cat.Name}");

                Console.Write("Número da categoria a ser deletada.");
                repository.Delete(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Cadastro deletado com sucesso!");
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