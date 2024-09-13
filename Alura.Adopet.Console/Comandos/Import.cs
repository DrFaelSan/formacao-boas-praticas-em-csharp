using System;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import",
    documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet _httpClientPet;
    private readonly LeitorDeArquivo _leitor;

    public Import(HttpClientPet httpClientPet, LeitorDeArquivo leitor)
    {
        _httpClientPet = httpClientPet;
        _leitor = leitor;
    }

    public async Task<Result> ExecutarAsync()
        => await ImportacaoArquivoPetAsync();

    private async Task<Result> ImportacaoArquivoPetAsync()
    {
        try
        {
            IEnumerable<Pet> listaDePet = _leitor.RealizaLeitura();

            foreach (var pet in listaDePet)
                await _httpClientPet.CreatePetAsync(pet);

            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet,"Importação Realizada com sucesso!"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
        }
    }
}
