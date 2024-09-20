# Principio OCP - aberto e fechado ao mesmo tempo

Seguir o Open/Closed Principle (OCP) é fundamental para projetos que aspiram evoluir de forma sustentável e estável. Afinal, nos, pessoas desenvolvedoras, queremos que nossos projetos de software vão além da primeira versão. Em seguida, vamos explorar o OCP, seus conceitos e alguns exemplos reais de aplicação.

Robert Martin foi o responsável por propagar este importante princípio (tio Bob cita como autores Ivar Jacobson e Bertrand Meyer). Seu enunciado está descrito abaixo:

`Toda entidade de software deve estar aberta a ampliações e fechada a mudanças.`

Como traduzir? Pense na aplicação que você está trabalhando atualmente na empresa. Ou mesmo algum projeto de software que já implementou. Imagine que tal projeto precisa se adequar a uma mudança.

Como será o processo no código? Doloroso? Tranquilo? Impossível? Em geral uma mudança que exija que vários arquivos sejam alterados é perigosa, podendo causar grande impacto. Em contrapartida, uma mudança que seja implementada com a inclusão de alguns poucos arquivos é menos sentida. Em resumo, mudanças aplicadas em projetos que seguem o OCP são feitas através da inclusão de novo código e não pela edição de código já existente.

A maneira de manter um sistema aberto a ampliação e fechado a mudanças é usando abstrações. Quando declaramos uma interface com comportamentos específicos e bem definidos estamos permitindo que módulos que dependam desta abstração permaneçam fechados a mudanças.

### Código de exemplo

Em nosso projeto criamos uma interface para representar a execução de um comando e lutamos com unhas e dentes para manter suas implementações o mais flexíveis possíveis, justamente através de novas abstrações como `ILeitorDeArquivos<T>` e `IApiService<T>`.

Focando na abstração que realiza leitura de arquivos, agora podemos ter novas implementações desta abstração sem precisar modificar as classes que executam comandos que dependem dela. Mantemos uma arquitetura flexível e leve de manter!

### Estudo de caso com exemplos reais

Nós sempre buscamos trazer exemplos de outros contextos para os padrões e princípios ensinados neste curso. No caso do OCP não precisaremos ir longe.

O primeiro exemplo é um recurso da própria linguagem, que também apresentamos nesta aula: os métodos de extensão. Através deles conseguimos adicionar **(ampliar)** comportamentos a tipos que não temos controle sobre o código, ou seja, estão fechados. No vídeo nós estendemos o tipo `Assembly` para novos comportamentos `GetTipoComando()` e `GetFabricas()`. Estes métodos foram criados na classe estática `ComandosExtensions`.

O segundo exemplo é a biblioteca FluentResults, que adotamos desde o curso anterior. Ampliamos seu comportamento através da herança da classe Success: criamos três novos motivos de sucesso, o sucesso para importação de pets, para importação de clientes e para a documentação.

Para sair um pouco do contexto de aplicações console, gostaríamos de citar o famoso framework web da Microsoft Asp.NET Core. Nele podemos estender seu comportamento para atender as necessidades de nossa aplicação através da criação de novos controladores. Para isso adicionamos os novos arquivos:

- uma classe que representa o controlador em questão
- eventualmente uma classe que representa o modelo a ser tratado
- um arquivo que representa a exibição das informações ao fim do tratamento

### Referências

Aqui estão algumas referências para você aprofundar o princípio do OCP e os exemplos que citamos:

- Livro Princípios, Padrões e Práticas Ágeis de Software em C#, de Robert Martin
- [Artigo do Robert Martin sobre o princípio](https://blog.cleancoder.com/uncle-bob/2014/05/12/TheOpenClosedPrinciple.html)
- [Documentação sobre métodos de extensão](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
- [Visão geral do framework web Asp.NET Core](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0)
