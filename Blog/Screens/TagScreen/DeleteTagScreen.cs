using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreen
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Delete();
        }

        private static void Delete()
        {
            foreach (var item in new Repository<Tag>(Database.Connection).Get())
                Console.WriteLine($"{item.Id} - {item.Name}");

            Console.WriteLine();

            Console.Write("Informa a Tag para exclusão: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var repository = new Repository<Tag>(Database.Connection);
            
            if (repository.GetById(id) != null)
            {
                repository.Delete(repository.GetById(id));
                Console.WriteLine("Deletado com sucesso!");
                Thread.Sleep(2000);
                MenuTagScreen.Load();
            } else {
                Console.Clear();
                Console.WriteLine("Item não localizado, tente novamente!");
                Thread.Sleep(2000);
                Load();
            }
        }

    }
}