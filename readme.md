# Cartao de Vacina

Sistema que permite cadastrar Vacinas, Pessoas e efetuar a aplicacao das doses.


Para executar é necessário ter instalado:
- SQL Server

Ao executar a aplicacao ela irá cadastrar dados inicias no banco.

O banco de dados esta com a seguinte modelagem:
![](docs/estrutura-banco.png)

Desta forma, a cada pessoa cadastrada e gerada uma nova caderneta vinculada a ela. Cada dose que a pessoa tomar sera vinculada tambem a sua caderneta em forma de vacinacao.