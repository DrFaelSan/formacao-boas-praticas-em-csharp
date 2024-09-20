using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Mail;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factorys;
public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)   
        => tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    
    public IComando? CriarComando(string[] argumentos)
    {
        ILeitorDeArquivos<Pet>? leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoDoAquivo: argumentos[1]);
        PetService httpClientPet = new(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));

        if (leitor is null) return null;
        var import = new Import(httpClientPet, leitor);

        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        import.ProgressChanged += ProcessaProgresso.ProgressChanged;

        return import;
    }
}