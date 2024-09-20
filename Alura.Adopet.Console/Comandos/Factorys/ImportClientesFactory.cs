using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factorys;
public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
        => tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;

    public IComando? CriarComando(string[] argumentos)
    {
        var clieteService = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorCliente = LeitorDeArquivosFactory.CreateClienteFrom(caminhoDoAquivo: argumentos[1]);
        
        if (leitorCliente is null) return null;
        return new ImportClientes(clieteService, leitorCliente);
    }
}
