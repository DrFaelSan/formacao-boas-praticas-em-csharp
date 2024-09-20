using Alura.Adopet.Console.Comandos;
using System.Reflection;

namespace Alura.Adopet.Console.Utils;
public class Documentacao
{
    private Dictionary<string, DocComandoAttribute> docs;

    public Documentacao()
    {
        docs = Assembly.GetExecutingAssembly().GetTypes()
           .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
           .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
           .ToDictionary(d => d.Instrucao);
    }

    public IEnumerable<string> ListarDocumentacaoDeTodosComandos()
        => docs.Values
            .Select(doc => doc.Documentacao)
            .ToList();

    public IEnumerable<DocComandoAttribute> ListarDocComando()
        => docs.Values.ToList();

    public string? this[string key] => docs.TryGetValue(key, out DocComandoAttribute? documentacaoDesejada) ? documentacaoDesejada.Documentacao : null;

    public static Dictionary<string, DocComandoAttribute> ToDictionary(Assembly assemblyComOTipoDocComando)
    {
        return assemblyComOTipoDocComando.GetTypes()
         .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
         .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
         .ToDictionary(d => d.Instrucao);
    }

}
