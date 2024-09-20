using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivo;
public class LeitorDeArquivosJson<T> : ILeitorDeArquivos<T>
{
    private string _caminhoArquivo;

    public LeitorDeArquivosJson(string caminhoArquivo)
        =>  _caminhoArquivo = caminhoArquivo;

    public IEnumerable<T>? RealizaLeitura()
    {
        if(string.IsNullOrEmpty(_caminhoArquivo)) return null;

        using var stream = new FileStream(_caminhoArquivo, FileMode.Open, FileAccess.Read);
        var jsonOptions = new JsonSerializerOptions();
        jsonOptions.PropertyNameCaseInsensitive = true;
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream, jsonOptions) ?? Enumerable.Empty<T>();
    }
}