# Padrão Result

Conhecemos nesta aula o padrão chamado Result, que tem o objetivo de representar sucesso ou falha na execução de alguma operação, juntamente com informações que eventualmente sejam necessárias para lidar com o resultado (como vimos com o tipo SuccessWithPets).

Embora este padrão não exista nos livros que catalogam padrões de projeto (como por exemplo o famoso Design Patterns), é um conceito muito empregado no mercado e em projetos de software.

Como estudo de caso, podemos citar o tipo IActionResult, existente no framework para desenvolvimento de aplicações web Aspnet Core, como uma aplicação deste padrão (e influência para adotarmos essa solução aqui no curso). Nele, implementações dessa interface foram criadas para representar resultados específicos a serem entregues como respostas HTTP. Alguns exemplos:

- ViewResult - representa um resultado que contém HTML e será renderizado pelo navegador
- NotFoundResult - representa um resultado que informa que o recurso não foi encontrado no servidor
- UnauthorizedResult - representa um resultado que informa que o solicitante não possui autorização para acessar o recurso no servidor
- OkObjectResult - representa um resultado de sucesso e entrega um objeto embutido em sua resposta

A seguir listamos algumas referências online, bem como o link da biblioteca FluentResults que nos ajuda na implementação deste padrão:

- [The Operation Result Pattern — A Simple Guide](https://medium.com/@cummingsi1993/the-operation-result-pattern-a-simple-guide-fe10ff959080)
- [Result Object Pattern](https://wiki.c2.com/?ResultObjectPattern)
- [The Operation Result Pattern](https://blog.upperdine.dev/the-operation-result-pattern)
- [My take on the Result class in C#](https://josef.codes/my-take-on-the-result-class-in-c-sharp/)
- [Documentação do tipo ViewResult](https://learn.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.mvc.viewresult?view=aspnetcore-8.0)
- [Documentação do tipo NotFoundResult](https://learn.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.mvc.notfoundresult?view=aspnetcore-8.0)
- [Documentação do tipo UnauthorizedResult](https://learn.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.mvc.unauthorizedresult?view=aspnetcore-8.0)
- [Documentação do tipo OkObjectResult](https://learn.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.mvc.okobjectresult?view=aspnetcore-8.0)
- [Biblioteca FluentResults](https://github.com/altmann/FluentResults)