using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import",
    documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando, IDepoisDaExecucao, ITrabalhoEmProgresso
{
    private readonly IApiService<Pet> _httpClientPet;
    private readonly ILeitorDeArquivos<Pet> _leitor;
    public event Action<Result>? DepoisDaExecucao;
    public event Action<int, int> ProgressChanged;

    public Import(IApiService<Pet> httpClientPet, ILeitorDeArquivos<Pet> leitor)
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
            IEnumerable<Pet>? listaDePet = _leitor.RealizaLeitura();

            int i = 0;
            foreach (var pet in listaDePet)
            {
                i++;
                await _httpClientPet.CreateAsync(pet);
                OnProgressChanged(i, listaDePet.Count());
            }
            var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet,"Importação Realizada com sucesso!"));
            
            DepoisDaExecucao?.Invoke(resultado);
            
            return resultado;
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
        }
    }

    private void OnProgressChanged(int i, int total)
    {
        ProgressChanged?.Invoke(i, total);
        Thread.Sleep(100);
    }
}
