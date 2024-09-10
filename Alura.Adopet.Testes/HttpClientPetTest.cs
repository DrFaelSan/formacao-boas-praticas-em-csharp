using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes;

public class HttpClientPetTest
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmListaNaoVazia()
    {
        //Arrange
        HttpClientPet clientPet = new();
        
        //Act
        var lista = await clientPet.ListPetsAsync();
        
        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async Task QuandoAPIForaDeveRetornarUmExececao()
    {
        //Arrange
        HttpClientPet clientPet = new(uri: "http://localhost:1111");

        //Act + Assert
        await Assert.ThrowsAnyAsync<Exception>(() => clientPet.ListPetsAsync());
    }
}