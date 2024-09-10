using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils;
public class LeitorDeArquivo
{
    public IEnumerable<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        List<Pet> listaDePet = new();
        using (StreamReader sr = new(caminhoDoArquivoASerLido))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
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
