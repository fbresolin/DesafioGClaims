# DesafioGClaims

Guia para rodar a aplicação:
- Para implementar o database deve ser rodado o script "DesafioGClaimsDb.sql" que está na raiz do diretório;
- É necessário fazer um cadastro para visualizar os personagens e realizar ações na aplicação;

Esta aplicação utiliza o .Net Core 3.1 e o Sql Server. Para lidar com o banco de dados da aplicação eu utilizei comandos Sql.

A aplicação foi implementada utilizando a estrutura ASP.NET Core MVC e possui uma tela de registro e login, e ao realizar login é possível filtrar personagens e salvá-los como favoritos no banco de dados. A aplicação está dividida em três bibliotecas, "MarvelApi" busca dados da Api da Marvel, "DataService" realiza operações sobre o banco de dados e "Entities" são os modelos utilizados.
