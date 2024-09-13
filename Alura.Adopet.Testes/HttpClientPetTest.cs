using Alura.Adopet.Console.Servicos;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes;

public class HttpClientPetTest
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmListaNaoVazia()
    {
        //Arrange
        var handleMock = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(@"
                [
                    {
                        ""id"":""0f8fad5b-d9cb-469f-a165-70867728950e"",
                        ""nome"": ""Sábio"",
                        ""tipo"": 0,
                        ""proprietario"": null
                    },
                    {
                         ""id"":""7c9e6679-7425-40de-944b-e07fc1f90ae7"",
                        ""nome"": ""Bidu"",
                        ""tipo"": 1,
                        ""proprietario"": null
                    }
                ]
            ")
        };

        handleMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handleMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

        HttpClientPet clientPet = new(httpClient.Object);
        
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
        var handleMock = new Mock<HttpMessageHandler>();

        handleMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new SocketException());

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handleMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

        HttpClientPet clientPet = new(httpClient.Object);

        //Act + Assert
        await Assert.ThrowsAnyAsync<Exception>(() => clientPet.ListPetsAsync());
    }
}