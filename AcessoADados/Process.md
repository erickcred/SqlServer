### Microsoft ADO.NET (Active Data Object) o que é?

A ideia dele é fornecer uma base para acesso a dados ele contém os componentes padrões de acesso a dados fornecidos pela Microsoft, e depois outros pacotes são criados em cima dele (Entity Framework, Dapper) ele tem como base o ADO.NET, mas no momento não se recomenta estudar a fundo o ADO.NET, somente para poder ver como é o seu funcionamento.


#### Primeiro processo Connection String => String de Conexão
Conexão com autenticação Windows "Server=localhost,1433;Database=erickcred;User ID=sa;Password=123"
Conexão com autenticação Sql "Server=localhost,1433;Database=erickcred;integrated Security=SSPI"
- Para poder se conectar ao banco de dados vamos utiliza um pacote da (Microsoft.Data.SqlClient)
    para poder utilizar esse pacote vamos utilizar o nuget, para poder usar o nuget no Visal Studio Code vamos fazer o seguite processo
    mas antes para pode encontrar esse pacote vamos para a web nesse caso vamos (https://www.nuget.org/profiles/Microsoft) para outros casos
    damos preferencia para pacotes que constão no github.

    para poder instalar o pacote (dotnet add package Microsoft.Data.SqlClient) e para remover um pacote (dotnet remove package Microsoft.Data.SqlClient)