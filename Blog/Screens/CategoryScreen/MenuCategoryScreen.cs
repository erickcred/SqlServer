using System;

namespace Blog.Screens.CategoryScreen
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();

            Console.WriteLine(
                "Gerenciamento de Role\n" + 
                "---------------------\n" + 
                "1 - Listar\n" + 
                "2 - Cadatrar\n" +
                "3 - Atualizar\n" + 
                "4 - Excluir\n\n" +
                "0 - Voltar para Blog" +
                "\n---------------------"
            );
            Console.WriteLine();

            try
            {
                short option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ListCategoryScreen.Load();
                        break;
                    case 2:
                        CreateCategoryScreen.Load();
                        break;
                    case 3:
                        UpdateCategoryScreen.Load();
                        break;
                    case 4:
                        DeleteCategoryScreen.Load();
                        break;
                    case 0:
                    default:
                        Load();
                        break;
                }
            } catch (FormatException erro)
            {
                Load();
            }
        }
    }
}