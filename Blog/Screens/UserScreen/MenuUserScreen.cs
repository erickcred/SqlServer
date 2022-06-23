using System;

namespace Blog.Screens.UserScreen
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();

            Console.WriteLine(
                "Gerenciamento de Usuário\n" + 
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
                        ListUserScreen.Load();
                        break;
                    case 2:
                        CreateUserScreen.Load();
                        break;
                    case 3:
                        UpdateUserScreen.Load();
                        break;
                    case 4:
                        DeleteUserScreen.Load();
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