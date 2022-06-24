using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Categoria");
            Update();
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

        private static void Update()
        {
            try
            {
                var category =  new Category();
                var repository = new CategoryRepository(Database.Connection);
                foreach (var cat in repository.ReadCategoryAndQuantityPost())
                {
                    Console.WriteLine($"{cat.Id} - {cat.Name}, {cat.Slug}, {cat.TotalPost}");
                    category.TotalPost = cat.TotalPost;
                }

                Console.Write("Número da categoria: ");
                category.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nome: ");
                category.Name = Console.ReadLine();
                Console.Write("Slug: ");
                category.Slug = Console.ReadLine();

                repository.Update(category);
                Console.WriteLine("Cadastro atualizado com sucesso!");
                Thread.Sleep(2500);
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