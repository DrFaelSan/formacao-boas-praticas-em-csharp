using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utils;
using System.Reflection;

namespace Alura.Adopet.Testes.Util;
public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              Documentacao.ToDictionary(assemblyComOTipoDocComando);

        //Assert            
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(5, dicionario.Count);

    }
}

