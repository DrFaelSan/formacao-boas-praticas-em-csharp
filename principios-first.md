# Princípios F.I.R.S.T

Os testes limpos são uma abordagem que vem sendo aplicada no desenvolvimento de software e visa garantir maior qualidade e manutenibilidade no código de testes. O termo “testes limpos”

surge na literatura técnica de sistemas no livro Código Limpo de Robert C. Martin (Uncle bob), do ano de 2009.

O objetivo dos testes limpos é a criação de testes unitários que sejam claros, mais concisos e eficientes, que permitam a pessoa desenvolvedora validar o comportamento das unidades individuais de código de forma isolada.

Uncle Bob apresenta um conjunto de princípios que ajuda na criação de testes limpos. Essas diretrizes são representadas pelo acrônimo F.I.R.S.T. onde cada letra corresponde a um princípio:

- F (Fast): Os testes devem ser rápidos tanto na escrita quanto em sua execução, o ideal é que consigamos executá-los frequentemente durante o desenvolvimento da aplicação. Isso possibilita um feedback rápido sobre a qualidade do código e ajuda a mitigar problemas de forma precoce.

- I (Isolated/Independent): No princípio I o objetivo é fazer que os testes sejam independentes uns dos outros e não devem depender da ordem de execução. Isso garante que cada teste valide uma única unidade de código, isolando-a de outras dependências.

- R (Repeatable): A possibilidade de conseguir repetir os testes em qualquer ambiente ou máquina, sem depender de fatores externos ou estado compartilhado. Isso evita inconsistências nos resultados dos testes.

- S (Self-validating): Os testes devem ser auto validados, ou seja, devem ser capazes de indicar automaticamente se passaram ou falharam. Isso permite que os desenvolvedores identifiquem rapidamente problemas no código.

- T (Timely): Os testes devem ser escritos em tempo hábil, idealmente antes da implementação do código real, um reforça na aplicação do TDD. Testes oportunos permitem que os desenvolvedores validem seu código à medida que o desenvolvem, facilitando a detecção precoce de erros.

(MARTIN, Robert C. Código Limpo: Habilidades Práticas do Agile Software". Rio de Janeiro: Alta Books Editora, 2009).

Para saber mais sobre os testes limpos e os princípios F.I.R.S.T. fica a recomendação de consultar o capítulo 9 “Testes de Unidade” do livro “Código Limpo, Habilidades práticas do Agile Software” de Robert C. Martin.
