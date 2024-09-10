using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Testes;
public class DocumentacaoTest
{
    [Fact]
    public void ListaDocComandosDeveRetornarUmListaNaoVazia()
    {
        //Arrange
        Documentacao documentacao = new();
        
        //Act 
        IEnumerable<DocComandoAttribute> lista = documentacao.ListarDocComando();

        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }
}
