namespace Alura.Adopet.Console.Comandos;
public class ComandosDoSistema
{
    private Dictionary<string, IComando> ComandosDisponiveis;

    public ComandosDoSistema()
    {
        ComandosDisponiveis = new()
            {
                {"import", new Import()},
                {"help", new Help()},
                {"show", new Show()},
                {"list", new List()},
            };
    }

    public IComando? this[string key] => ComandosDisponiveis.TryGetValue(key, out IComando? comandoDesejado) ? comandoDesejado : null;
}
