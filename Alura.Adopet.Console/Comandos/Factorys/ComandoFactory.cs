using Alura.Adopet.Console.Extensions;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos.Factorys;
public static class ComandoFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if (argumentos is null || argumentos.Length == 0)
            return null;

        var comando = argumentos[0];

        Type? tipoRetornado = Assembly.GetExecutingAssembly().GetTipoComando(comando);

        IEnumerable<IComandoFactory?> listaDeFabricas = Assembly.GetExecutingAssembly().GetFabricas();

        IComandoFactory? fabrica = listaDeFabricas.FirstOrDefault(f => f!.ConsegueCriarOTipo(tipoRetornado));

        if (fabrica is null) return null;

        return fabrica.CriarComando(argumentos);
    }
}