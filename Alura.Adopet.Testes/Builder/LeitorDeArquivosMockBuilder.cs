using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Moq;

namespace Alura.Adopet.Testes.Builder;
public static class LeitorDeArquivosMockBuilder
{
    public static Mock<LeitorDeArquivo> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());
        leitorDeArquivo.Setup(leitor => leitor.RealizaLeitura()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}
