using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils;
public class LeitorDeArquivo
{
    private string? _caminhoArquivo;
    public LeitorDeArquivo(string caminhoDoArquivo)
        => _caminhoArquivo = caminhoDoArquivo;

    //public virtual IEnumerable<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    //{

    //    List<Pet> listaDePet = new();
    //    using (StreamReader sr = new(caminhoDoArquivoASerLido))
    //    {
    //        while (!sr.EndOfStream)
    //        {
    //            string? linha = sr?.ReadLine();
    //            if (linha is not null)
    //                listaDePet.Add(linha.ConverterDoTexto());
    //        }
    //    }
    //    return listaDePet;

    //}

    public virtual IEnumerable<Pet> RealizaLeitura()
    {

        List<Pet> listaDePet = new();

        if (string.IsNullOrEmpty(_caminhoArquivo) || !File.Exists(_caminhoArquivo)) return null;

        using (StreamReader sr = new(_caminhoArquivo))
        {
            while (!sr.EndOfStream)
            {
                string? linha = sr?.ReadLine();
                if (linha is not null)
                    listaDePet.Add(linha.ConverterDoTexto());
            }
        }
        return listaDePet;

    }
}
