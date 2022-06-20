using System;
using Blog.Repositories;
using Blog.Models;
using Blog;

namespace Blog.Screens.TagScreen
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Update();
        }

        private static void Update()
        {
            foreach (var item in new Repository<Tag>(Database.Connection).Get())
                Console.WriteLine($"{item.Id} - {item.Name}, {item.Slug}");
            Console.WriteLine("Selecione uma categoria para atualizar!");
            int id = Convert.ToInt32(Console.ReadLine());
            

            var tag = new Tag();
            tag.Id = id;
            Console.Write("Nome: ");
            tag.Name = Console.ReadLine();
            Console.Write("Slug: ");
            tag.Slug = Console.ReadLine();
            if (tag.Name.Equals("") || tag.Slug.Equals("") || tag.Id == null)
            {
                Console.WriteLine("Todos os campos devem ser preechidos!");

                Console.WriteLine("Selecione uma categoria para atualizar!");
                id = Convert.ToInt32(Console.ReadLine());
                
                tag.Id = id;
                Console.Write("Nome: ");
                tag.Name = Console.ReadLine();
                Console.Write("Slug: ");
                tag.Slug = Console.ReadLine();
            } else 
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Cadatro atualizado com sucesso!");
                Thread.Sleep(2000);
                MenuTagScreen.Load();
            }

        }
    }
}