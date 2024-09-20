# Configuração de aplicações .NET

No vídeo anterior conhecemos mais uma boa prática, agora associada às configurações de uma aplicação NET, seja ela do tipo console, desktop ou web:

```
Dados que fazem parte da configuração de uma aplicação, dos seus serviços e componentes de infraestrutura, dentre outros, devem ser armazenados fora do código.

Que tipo de dados de configuração são esses? Em geral aqueles que são mantidos por administradores da infraestrutura da aplicação ou de serviços utilizados por ela. Por exemplo:
```

- endereços web de APIs ou outros serviços web
- credenciais de autenticação/autorização a estes serviços
- strings de conexão para acesso a bancos de dados
- informações complementares a estes serviços

A ideia central para o armazenamento externo é não precisarmos compilar e publicar uma aplicação toda vez que algum dado de configuração mudar.

### Formato de um dado de configuração

Uma informação de configuração segue o formato chave/valor, podendo ser agrupado em categorias. O conteúdo de um arquivo json cuja função fosse armazenar dados de configuração poderia ser:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  },
  "AllowedHosts": "_"
}
```

Nele temos três chaves, Default, Microsoft e AllowedHosts; enquanto seus valores são Information, Warning, e \_ respectivamente. Estas chaves estão agrupadas em categorias e subcategorias para melhor organização e uso dentro do sistema.

### Fontes de armazenamento

Onde ficam armazenados estes dados? Aqui entra um termo que a Microsoft denominou **Configuration Providers**. Os configuration providers são abstrações que representam variadas fontes de configuração: arquivos de configuração (a fonte mais comum e ilustrada na seção anterior), variáveis de ambiente, componentes de nuvem, bancos de dados, memória, dentre outras.

Em nosso exemplo definimos como configuration provider o arquivo appsettings.json. Para isso criamos o arquivo, colocando os dados lá dentro. O passo seguinte é tornar as configurações visíveis no momento em que forem necessárias.

Aqui entra outro conceito da Microsoft, chamado Binding, que é a capacidade de vincular valores de configuração a objetos .NET. Em nosso exemplo, primeiro criamos a classe AppSettings para representar estes dados:

```csharp
public class AppSettings
{
  public const string Section = "AdopetApi";
  public string Uri { get; set; } = string.Empty;
}
```

E por fim criamos outra classe para disponibilizar este objeto sempre que necessário:

```csharp
public static class Configurations
{

  private static IConfiguration BuildConfiguration()
  {
    return new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
  }

  public static AppSettings AppSetting
  {
    get
    {
      var _config = BuildConfiguration();
      return _config
          .GetSection(AppSettings.Section)
          .Get<AppSettings>() ??
          throw new ArgumentException("Seção para configuração da API não encontrada!");
    }
  }
}
```

No código acima, o objeto do tipo AppSetting é entregue via propriedade estática. Sempre que exigida, a propriedade constrói a configuração e faz o binding para o objeto. Se a seção não for encontrada, uma exceção é lançada.

### O padrão Builder

O bacana deste código é que podemos ver na prática o padrão Builder sendo empregado. Recapitulando: sempre que o processo de instanciação de um objeto for complexo, extraímos essa complexidade para uma classe com responsabilidade exclusiva de construção: olha o padrão Builder aí, gente! Chora cavaco! Perdão, me empolguei…

Aliás, a Microsoft utiliza o padrão Builder para configurar vários recursos de suas bibliotecas, desde conexão com banco de dados no Entity Framework Core até as rotas Http no framework Asp.NET Core.

### Referências

Como sempre, deixamos aqui algumas sugestões de aprofundamento para você estudar no final de semana:

- [Visão geral](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration) da MS sobre o processo de configuração de uma aplicação;
- [Página do Refactoring Guru](https://refactoring.guru/pt-br/design-patterns/builder) sobre o padrão Builder.
