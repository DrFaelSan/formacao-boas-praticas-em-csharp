using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils;
public static class PetApartirDoCsv
{
    public static Pet ConverterDoTexto(this string? linhaCsv)
    {
        string[]? propriedades = linhaCsv?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

        if(string.IsNullOrEmpty(linhaCsv)) throw new ArgumentException("Texto não pode ser vazio!");

        if (propriedades.Length != 3) throw new ArgumentException("TextoInválido");

        bool sucesso = Guid.TryParse(propriedades[0], out Guid petId);
        if (!sucesso) throw new ArgumentException("Guid inválido!");

        sucesso = int.TryParse(propriedades[2], out int tipoPet);
        var tiposValidos = new List<int> {(int)TipoPet.Gato,(int)TipoPet.Cachorro};

        if (!sucesso || !tiposValidos.Contains(tipoPet)) throw new ArgumentException("Tipo de Pet inválido");

        return  new(petId,propriedades[1],(TipoPet)tipoPet);
    }

    public static int QuantidadeDeCampos(this string linhaCsv)
    {
        string[]? propriedades = linhaCsv.Split(';');
        return propriedades.Length;
    }

    public static bool GuidEhValido(this string linhaCsv)
    {
        string[]? propriedades = linhaCsv.Split(';');
        return Guid.TryParse(propriedades[0], out Guid _);
    }
}
