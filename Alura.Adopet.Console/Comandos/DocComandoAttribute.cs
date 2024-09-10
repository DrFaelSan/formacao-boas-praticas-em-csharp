namespace Alura.Adopet.Console.Comandos;

[AttributeUsage(AttributeTargets.Class)]
public class DocComandoAttribute : Attribute
{
    public DocComandoAttribute(string instrucao, string documentacao)
    {
        Instrucao = instrucao;
        Documentacao = documentacao;
    }

    public string Instrucao { get; set; }
    public string Documentacao { get; set; }
}
