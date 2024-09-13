using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos;
public static class FabricaDeComandos
{
    public static IComando? CriarComando(string[] argumentos)
    {
        var comando = argumentos[0];
        switch (comando)
        {
            case "import":
                return new Import(usarHttpClientPet(), usarLeitorDeArquivo(caminhoDoArquivo:argumentos[1]));
            case "list":
                return new List(usarHttpClientPet());
            case "show":
                return new Show(usarLeitorDeArquivo(caminhoDoArquivo:argumentos[1]));
            case "help":
                var comandoASerExibido = argumentos.Length == 2 ? argumentos[1] : null;
                return new Help(comandoASerExibido);
            default: return null;
        }
    }

    private static HttpClientPet usarHttpClientPet() 
        => new(new AdopetAPIClientFactory().CreateClient("adopet"));

    private static LeitorDeArquivo usarLeitorDeArquivo(string caminhoDoArquivo)
      => new(caminhoDoArquivo);
}
