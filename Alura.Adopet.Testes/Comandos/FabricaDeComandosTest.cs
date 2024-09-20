using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Comandos.Factorys;

namespace Alura.Adopet.Testes.Comandos;
public class FabricaDeComandosTest
{

    [Theory]
    [InlineData("import", "Import")]
    [InlineData("import-clientes", "ImportClientes")]
    [InlineData("show", "Show")]
    [InlineData("list", "List")]
    [InlineData("help", "Help")]
    public void DadoParametroValidoDeveRetornarObjetoNaoNulo(string instrucao, string nomeTipo)
    {
        // arrange
        string[] args = new[] { instrucao, "lista.csv" };
        // act
        var comando = ComandoFactory.CriarComando(args);
        // assert
        Assert.NotNull(comando);
        Assert.Equal(nomeTipo, comando.GetType().Name);
    }

    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoImport()
    {
        //Arrange
        string[] args = { "import", "lista.csv" };
        //Act
        IComando? comando = ComandoFactory.CriarComando(args);
        //Assert
        Assert.IsType<Import>(comando);
    }

    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoList()
    {
        //Arrange
        string[] args = { "list"};
        //Act
        IComando? comando = ComandoFactory.CriarComando(args);
        //Assert
        Assert.IsType<List>(comando);
    }

    [Fact]
    public void DadoUmParametroInvalidoDeveRetornarNulo()
    {
        //Arrange
        string[] args = { "invalid", "lista.csv" };
        //Act
        IComando? comando = ComandoFactory.CriarComando(args);
        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
    {
        //Arrange           
        //Act
        IComando? comando = ComandoFactory.CriarComando(null);
        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosVazioDeveRetornarNulo()
    {
        //Arrange
        string[] args = { };
        //Act
        IComando? comando = ComandoFactory.CriarComando(args);
        //Assert
        Assert.Null(comando);
    }
}
