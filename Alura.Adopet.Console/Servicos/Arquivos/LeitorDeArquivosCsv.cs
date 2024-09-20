using System;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivo;
public abstract class LeitorDeArquivosCsv<T> : ILeitorDeArquivos<T>
{
    private string? _caminhoArquivo;
    public LeitorDeArquivosCsv(string caminhoDoArquivo)
        => _caminhoArquivo = caminhoDoArquivo;

    public virtual IEnumerable<T>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(_caminhoArquivo))
            return null;
        
        List<T> lista = new();
        using StreamReader sr = new StreamReader(_caminhoArquivo);
        while (!sr.EndOfStream)
        {
            string? linha = sr.ReadLine();
            if (linha is not null)
            {
                var objeto = CriarDaLinhaCsv(linha);
                lista.Add(objeto);
            }
        }
        return lista;
    }

    public abstract T CriarDaLinhaCsv(string linha);
   
}
