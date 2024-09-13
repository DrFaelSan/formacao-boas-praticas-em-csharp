using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Moq;

namespace Alura.Adopet.Testes;
public class LeitorDeArquivoTest : IDisposable
{
    private string caminhoArquivo;

    public LeitorDeArquivoTest()
    {
        //Setup
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        File.WriteAllText("lista.csv", linha);
        caminhoArquivo = Path.GetFullPath("lista.csv");
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange
        var listaPets = new List<Pet>
            {
                new(Guid.NewGuid(), "Dog mau", TipoPet.Cachorro)
            };

        var leitorDeArquivoMock = new Mock<LeitorDeArquivo>(caminhoArquivo);

        leitorDeArquivoMock
           .Setup(leitor => leitor.RealizaLeitura())
           .Returns(listaPets);

        //Act
        var listaDePets = leitorDeArquivoMock.Object.RealizaLeitura();
        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange
        var caminhoInexistente = Path.Combine(Environment.CurrentDirectory, "teste.csv");
        var leitorDeArquivoMock = new Mock<LeitorDeArquivo>(caminhoInexistente);

        leitorDeArquivoMock
                .Setup(leitor => leitor.RealizaLeitura())
                .Returns<IEnumerable<Pet>?>(null);

        //Act
        var listaDePets = leitorDeArquivoMock.Object.RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange
        var leitorDeArquivoMock = new Mock<LeitorDeArquivo>(null);

        leitorDeArquivoMock
             .Setup(leitor => leitor.RealizaLeitura())
             .Returns<IEnumerable<Pet>?>(null);

        //Act
        var listaDePets = leitorDeArquivoMock.Object.RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}
