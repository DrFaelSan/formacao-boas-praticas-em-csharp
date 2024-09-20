using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Mail;

namespace Alura.Adopet.Console.Servicos.Mail;
public class SmtpClientMailService : IMailService
{
    private readonly SmtpClient _smtpClient;

    public SmtpClientMailService(SmtpClient smtpClient)
        =>  _smtpClient = smtpClient;

    public Task SendMailAsync(string remetente, string destinatario, string titulo, string corpo)
    {
        MailMessage message = new()
        {
            From = new MailAddress(remetente),
            Subject = titulo,
            Body = corpo
        };
        message.To.Add(new MailAddress(destinatario));
        _smtpClient.Send(message);
        return Task.CompletedTask;
    }
}
