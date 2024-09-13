using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help",
    documentacao: "adopet help comando que exibe informações de ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
public class Help : IComando
{
    private Documentacao Documentacao;
    private string? _comando;

    public Help(string? comando)
    {
        _comando = comando;
        Documentacao = new();

    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return Task.FromResult(Result.Ok()
                .WithSuccess(new SuccessWithDocs(GerarDocumentacao())));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(ex)));
        }
    }

    private IEnumerable<string> GerarDocumentacao()
    {
        List<string> resultado = new();
        if (_comando is null)
            resultado.AddRange(Documentacao.ListarDocumentacaoDeTodosComandos());
        else
        {
            string? helpComando = Documentacao[_comando];
            if (helpComando is not null)
                resultado.Add(helpComando);
            else
                resultado.Add("Comando não encontrado!");
        }

        return resultado;
    }
}
