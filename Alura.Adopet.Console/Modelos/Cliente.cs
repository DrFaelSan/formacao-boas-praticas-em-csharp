namespace Alura.Adopet.Console.Modelos;
public class Cliente
{
    public Cliente(string nome, string email, string? cpf = null, Guid? id = null)
    {
        Nome = nome;
        Email = email;

        if (cpf is not null)
            CPF = cpf;

        if(id is not null)
            Id = (Guid)id;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string? CPF { get; set; }

    public override string? ToString()
        =>  $"{Id} - {Nome} - {Email} - {CPF} ";
}
