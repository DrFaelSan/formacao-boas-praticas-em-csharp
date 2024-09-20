using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivo;

namespace Alura.Adopet.Console.Servicos.Arquivos;
public static class LeitorDeArquivosFactory
{
    public static ILeitorDeArquivos<Pet>? CreatePetFrom(string caminhoDoAquivo)
    {
        var extensao = Path.GetExtension(caminhoDoAquivo);

        switch (extensao)
        {
            case ".csv":
                return new PetsDoCsv(caminhoDoAquivo);
            case ".json":
                return new LeitorDeArquivosJson<Pet>(caminhoDoAquivo);
            default:
                return null;
        }
    }

    public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string caminhoDoAquivo)
    {
        var extensao = Path.GetExtension(caminhoDoAquivo);

        switch (extensao)
        {
            case ".csv":
                return new ClientesDoCsv(caminhoDoAquivo);
            case ".json":
                return new LeitorDeArquivosJson<Cliente>(caminhoDoAquivo);
            default:
                return null;
        }
    }
}
