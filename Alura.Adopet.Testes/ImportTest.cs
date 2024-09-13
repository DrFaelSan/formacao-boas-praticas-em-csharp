using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes;
public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        
        //Act
        await import.ExecutarAsync();

        //Assert
        httpClientPet.Verify(instancia=> instancia.CreatePetAsync(It.IsAny<Pet>()), Times.Never);

    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarFalha()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitor.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsFailed);
    }

    [Fact]
    public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        List<Pet> listaDePet = new()
        {
            new(Guid.NewGuid(), "Lima", TipoPet.Cachorro)
        };

        var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitor.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsSuccess);
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Lima", sucesso.Data.First().Nome);
    }
}
