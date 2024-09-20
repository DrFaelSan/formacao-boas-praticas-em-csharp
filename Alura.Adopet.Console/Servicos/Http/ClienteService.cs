using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http;
public class ClienteService : IApiService<Cliente>
{
    private HttpClient _client;

    public ClienteService(HttpClient client)
        =>  _client = client;

    public Task<HttpResponseMessage> CreateAsync(Cliente cliente)
    {
        using HttpResponseMessage? response = new();
        return _client.PostAsJsonAsync("cliente/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
    }
}
