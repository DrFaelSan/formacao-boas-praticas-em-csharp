# Delegates

No C# existe o recurso dos Delegates: estes representam um tipo de dado que aponta para um método. Utilizamos Delegates para passar métodos como parâmetros para outros métodos, ou ainda para armazenar métodos em coleções. Usualmente os utilizamos para implementar callbacks e eventos.

Podemos elencar as seguintes propriedades dos Delegates:

- Podem ser passados como parâmetros para métodos;
- Permite que múltiplos métodos sejam invocados em um único evento;
- Introduz no conceito de métodos anônimos o que permite que possamos passar um bloco de código para um método, o que elimina a necessidade de criarmos métodos separados.

Para criarmos um Delegate usamos a palavra reservada `delegate` Por exemplo ao definirmos o delegate `public delegate string NotificacaoEventHandler(string mensagem)`, queremos dizer que este delegate pode referenciar qualquer método que respeita a sua assinatura.

Sendo assim, podemos criar uma instância do nosso delegate e referenciar um método como no exemplo.

- 1º Método com assinatura compatível com o delegate.

```csharp

    public string GetMensagem(string mensagem)
    {
        return mensagem;
    }

```

- 2º Criar a instância do delegate.

```csharp

    NotificacaoEventHandler notificacao = GetMensagem;
    Console.WriteLine(notificacao(“Ocorreu uma notificação!”));

```

A utilização de delegates é bem útil quando você deseja implementar callbacks, como em eventos, onde uma classe pode notificar outras partes do código quando algo acontece. Pode-se utilizá-los também em construções de expressões LINQ para criar consultas em coleções de uma maneira mais elegante.

Para saber mais sobre o tema dos Delegates, confira as referências abaixo:

- [Documentação - Delegados (Guia de Programação em C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/delegates/)
- [Documentação - Usando delegados (Guia de Programação em C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/delegates/using-delegates)
- [Artigo - How to work with delegates in C#](https://www.infoworld.com/article/2240268/how-to-work-with-delegates-in-csharp.html)
