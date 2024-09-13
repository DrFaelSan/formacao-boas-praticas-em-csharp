using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;
using FluentResults;

IComando? comando = FabricaDeComandos.CriarComando(args);
if (comando is not null)
    ConsoleUI.ExibeResultado(await comando.ExecutarAsync());
else 
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));