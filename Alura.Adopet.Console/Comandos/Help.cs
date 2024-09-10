using Alura.Adopet.Console.Utils;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help",
    documentacao: "adopet help comando que exibe informações de ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
public class Help : IComando
{
    private Documentacao Documentacao;

    public Help()
        =>  Documentacao = new();
    
    public Task ExecutarAsync(string[] args)
    {
        ListarComandos(args);
        return Task.CompletedTask;
    }

    private void ListarComandos(string[] comandos)
    {
        System.Console.WriteLine("Lista de comandos.");
        if (comandos.Length == 1)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            Documentacao.ListarDocumentacaoDeTodosComandos();
        }
        // exibe o help daquele comando específico
        else if (comandos.Length == 2)
        {
            string comandoASerExibido = comandos[1];
            string? helpComando = Documentacao[comandoASerExibido];
            if(helpComando is not null)
                System.Console.WriteLine(helpComando);
        }
    }
}
