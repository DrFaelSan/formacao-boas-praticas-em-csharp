namespace Alura.Adopet.Console.Comandos.Factorys;
public interface IComandoFactory
{
    IComando? CriarComando(string[] argumentos);
    bool ConsegueCriarOTipo(Type? tipoComando);
}