using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Testes;
public class PetApartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaDeveRetornarUmPet()
    {
        //Arrange
        string conteudoValido = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        
        //Act
        Pet pet = conteudoValido.ConverterDoTexto();
        
        //Assert
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringNulaDeveLancarArgumentNullException()
    {
        //Arrange
        string? linha = null;

        //Act + Assert 
        Assert.Throws<ArgumentNullException>(() => linha.ConverterDoTexto());
    }

    [Fact]
    public void QuandoStringVaziaDeveLancarArgumentException()
    {
        //Arrange
        string? linha = string.Empty;

        //Act + Assert 
        Assert.Throws<ArgumentException>(() => linha.ConverterDoTexto());
    }


    [Fact]
    public void QuandoCamposInsuficientesDeveLancarArgumentException()
    {
        //Arrange
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

        //Act + Assert 
        Assert.Throws<ArgumentException>(() => linha.ConverterDoTexto());
    }

    [Fact]
    public void QuandoGuidInvalidoDeveLancarArgumentException()
    {
        //Arrange
        string linha = "2j1hn12nhjwq;Lima Limão;1";

        //Act + Assert 
        Assert.Throws<ArgumentException>(() => linha.ConverterDoTexto());
    }

    [Fact]
    public void QuandoTipoInvalidoDeveLancarArgumentException()
    {
        //Arrange
        string linha = "2j1hn12nhjwq;Lima Limão;2";

        //Act + Assert 
        Assert.Throws<ArgumentException>(() => linha.ConverterDoTexto());
    }

}
