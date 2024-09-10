using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show",
    documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n")]
public class Show : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        ExibirArquivosAImportados(caminhoArquivoASerExibido: args[1]);
        return Task.CompletedTask;
    }

    private void ExibirArquivosAImportados(string caminhoArquivoASerExibido)
    {
        LeitorDeArquivo leitor = new();
        var listaDePets = leitor.RealizaLeitura(caminhoArquivoASerExibido);
        foreach (var pet in listaDePets)
            System.Console.WriteLine(pet);

    }
}
