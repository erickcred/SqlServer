using System;

namespace Blog.Screens.TagScreen
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();

            Console.WriteLine(
                "Gerenciamento de Tags\n" + 
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
                        ListTagsScreen.Load();
                        break;
                    case 2:
                        CreateTagScreen.Load();
                        break;
                    case 3:
                        UpdateTagScreen.Load();
                        break;
                    case 4:
                        DeleteTagScreen.Load();
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