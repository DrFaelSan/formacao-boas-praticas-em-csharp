﻿using Alura.Adopet.Console.Modelos;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos;
public class HttpClientPet
{
    private HttpClient client;

    public HttpClientPet(HttpClient client)
    {
        this.client = client;
    }

    public virtual Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        using HttpResponseMessage? response = new();
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
