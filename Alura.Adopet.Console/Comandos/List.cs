using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list",
    documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da Adopet.")]
public class List : IComando
{
    private readonly HttpClientPet _httpClientPet;

    public List(HttpClientPet httpClientPet) => _httpClientPet = httpClientPet;

    public async Task<Result> ExecutarAsync()
        => await ListarPetsExistentesAsync();

    private async Task<Result> ListarPetsExistentesAsync()
    {
        try
        {
            var pets = await _httpClientPet.ListPetsAsync() ?? Enumerable.Empty<Pet>();
            return Result.Ok().WithSuccess(new SuccessWithPets(pets));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(ex));
        }
    }
}
