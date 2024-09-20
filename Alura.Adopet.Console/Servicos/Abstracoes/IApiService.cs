namespace Alura.Adopet.Console.Servicos.Abstracoes;
public interface IApiService<T> where T : class
{
    Task<HttpResponseMessage> CreateAsync(T modelo);
    Task<IEnumerable<T>?> ListAsync();
}