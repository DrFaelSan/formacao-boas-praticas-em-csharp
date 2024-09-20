using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Properties;

[DocComando(instrucao: "list-clientes",
    documentacao: "adopet list-clientes comando que exibe no" +
    " terminal o conteúdo de clientes na base de dados da AdoPet.")]
public class ListClientes : IComando
{
    private readonly IApiService<Cliente> _service;

    public ListClientes(IApiService<Cliente> service)
        =>  _service = service;

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Cliente>? clientes = await _service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de Clientess realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}
