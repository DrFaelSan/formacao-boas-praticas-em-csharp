using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show",
    documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n")]
public class Show : IComando
{
    private readonly ILeitorDeArquivos<Pet> _leitor;

    public Show(ILeitorDeArquivos<Pet> leitor)
        => _leitor = leitor;

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            return await Task.FromResult(ExibirArquivosAImportados());
        }
        catch (Exception ex)
        {
            return await Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(ex)));
        }
    }

    private Result ExibirArquivosAImportados()
    {
        var listaDePets = _leitor.RealizaLeitura();
        return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição do arquivo realizada com sucesso!"));
    }
}
