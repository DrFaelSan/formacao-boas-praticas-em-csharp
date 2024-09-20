using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivo;
using Moq;

namespace Alura.Adopet.TestesIntegracao.Builder;
public static class LeitorDeArquivosMockBuilder
{
    public static Mock<LeitorDeArquivosCsv<Pet>> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivosCsv<Pet>>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}
