﻿using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factorys;
public class ListFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
       => tipoComando?.IsAssignableTo(typeof(List)) ?? false;

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPetList = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new List(httpClientPetList);
    }
}