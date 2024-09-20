using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Servicos.Http;
public class AdopetAPIClientFactory : IHttpClientFactory
{
    private string _url;

    public AdopetAPIClientFactory(string url)
        =>  _url = url;

    public HttpClient CreateClient(string name)
    {
        HttpClient _client = new(){};
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(_url);
        return _client;
    }
}
