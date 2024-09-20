using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivo;

namespace Alura.Adopet.Console.Servicos.Arquivos;
public class ClientesDoCsv : LeitorDeArquivosCsv<Cliente>
{
    public ClientesDoCsv(string caminhoDoArquivo) : base(caminhoDoArquivo) {}

    public override Cliente CriarDaLinhaCsv(string linha)
    {
        string[] propriedades = linha.Split(';');

        bool guidValido = Guid.TryParse(propriedades[0], out Guid clienteId);
        if (!guidValido) throw new ArgumentException("Identificador do cliente inválido!");

        return new(
                nome: propriedades[1],
                email: propriedades[2],
                cpf: propriedades[3],
                id: clienteId
            );
    }
}
