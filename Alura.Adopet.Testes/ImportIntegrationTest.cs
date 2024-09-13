using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Testes.Builder;

namespace Alura.Adopet.Testes;
public class ImportIntegrationTest
{
    [Fact]
    public async void QuandoAPIEstaNoARDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>
        {
            new(Guid.NewGuid(), "Cachorão de madame", TipoPet.Cachorro)
        };

        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopetAPI"));
        var import = new Import(httpClientPet, leitorDeArquivo.Object);

        //Act
        await import.ExecutarAsync();

        //Assert
        var listaPet = await httpClientPet.ListPetsAsync();
        Assert.NotNull(listaPet);
    }
}
