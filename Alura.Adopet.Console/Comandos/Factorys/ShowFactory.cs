using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos.Factorys;
public class ShowFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
        => tipoComando?.IsAssignableTo(typeof(Show)) ?? false;
    public IComando? CriarComando(string[] argumentos)
    {
        var leitorDeArquivosShow = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivosShow is null) { return null; }
        return new Show(leitorDeArquivosShow);
    }
}