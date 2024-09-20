using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http;
public class PetService : IApiService<Pet>
{
    private HttpClient _client;

    public PetService(HttpClient client)
        => _client = client;

    public virtual Task<HttpResponseMessage> CreateAsync(Pet pet)
    {
        using HttpResponseMessage? response = new();
        return _client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
