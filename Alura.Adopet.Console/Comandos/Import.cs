﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import",
    documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet httpClientPet;

    public Import()
        => httpClientPet = new HttpClientPet();

    public async Task ExecutarAsync(string[] args)
        =>  await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);

    private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {

        LeitorDeArquivo leitor = new();
        IEnumerable<Pet> listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);

        foreach (var pet in listaDePet)
        {
            System.Console.WriteLine(pet);
            try
            {
                var resposta = await httpClientPet.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }
}
