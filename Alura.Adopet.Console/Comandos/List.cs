using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list",
    documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da Adopet.")]
public class List : IComando
{
    private readonly HttpClientPet httpClientPet;

    public List() => httpClientPet = new HttpClientPet();

    public async Task ExecutarAsync(string[] args)
        => await ListarPetsExistentesAsync();

    private async Task ListarPetsExistentesAsync()
    {
        var pets = await httpClientPet.ListPetsAsync();
        foreach (var pet in pets)
            System.Console.WriteLine(pet);
    }
}
