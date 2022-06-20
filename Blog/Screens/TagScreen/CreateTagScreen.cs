using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreen
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Tag");
            Create();
        }

        private static void Create()
        {
            Tag tag = new Tag();
            Console.Write("Nome: ");
            tag.Name = Console.ReadLine();
            Console.Write("Slug: ");
            tag.Slug = Console.ReadLine();

            if (tag.Name.Equals("") && tag.Slug.Equals(""))
            {
                Console.WriteLine("Todos os campos devem ser preenchidos!");
                Thread.Sleep(200);
                Load();
            }

            var repository = new Repository<Tag>(Database.Connection);

            var result = repository.Create(tag);
            if (result != null)
            {
                Console.WriteLine("Cadastro realizado com sucesso!");
                Thread.Sleep(2000);
                MenuTagScreen.Load();
            }
        }
    }
}