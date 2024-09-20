using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivo;

namespace Alura.Adopet.Testes.Servicos;
public class LeitorDeArquivosJsonTest : IDisposable
{
    private string _caminhoArquivo;
    public LeitorDeArquivosJsonTest()
    {
        //Setup
        string linha = @"[{
                            ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                            ""Nome"": ""Alvo"",
                            ""Tipo"": 1
                          }]";

        string nomeRandomico = $"{Guid.NewGuid()}.json";

        File.WriteAllText(nomeRandomico, linha);
        _caminhoArquivo = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivosJson<Pet>(_caminhoArquivo).RealizaLeitura()!;
        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivosJson<Pet>("").RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivosJson<Pet>(null).RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(_caminhoArquivo);
    }
}