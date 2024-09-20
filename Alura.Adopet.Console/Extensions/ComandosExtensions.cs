using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Comandos.Factorys;
using System.Data;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions;
public static class ComandosExtensions
{
    public static Type? GetTipoComando(this Assembly assembly, string instrucao)
    {
        return assembly
            .GetTypes()
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando)))
            .FirstOrDefault(t => t.GetCustomAttributes<DocComandoAttribute>()
            .Any(d => d.Instrucao.Equals(instrucao)));
    }

    public static IEnumerable<IComandoFactory?> GetFabricas(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory)))
            .Select(f => Activator.CreateInstance(f) as IComandoFactory);
    }  
}
