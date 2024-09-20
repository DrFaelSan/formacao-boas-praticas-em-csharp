using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;
public static class Configurations
{
    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("c9b9020e-fb04-4223-adba-d9781bf03040") //<project>.csproj -> PropertyGroup ->  UserSecretsId
            .Build();
    }

    public static AppSettings ApiSetting
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(AppSettings.Section)
                .Get<AppSettings>() ??
                throw new ArgumentException("Seção para configuração da API não encontrada!");
        }
    }

    public static MailSettings MailSetting
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(MailSettings.EmailSection)
                .Get<MailSettings>() ??
                throw new ArgumentException("Seção para configuração do e-mail não encontrada!");
        }
    }
}