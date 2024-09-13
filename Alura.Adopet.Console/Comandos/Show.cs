using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show",
    documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n")]
public class Show : IComando
{
    private readonly LeitorDeArquivo _leitor;

    public Show(LeitorDeArquivo leitor)
        =>  _leitor = leitor;

    public async Task<Result> ExecutarAsync()
        =>  await Task.FromResult(ExibirArquivosAImportados());

    private Result ExibirArquivosAImportados()
    {
        try
        {
            var listaDePets = _leitor.RealizaLeitura();
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(ex));
        }
    }
}
