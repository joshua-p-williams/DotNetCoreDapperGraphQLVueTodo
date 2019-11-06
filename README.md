# DotNetCoreDapperGraphQLVueTodo
Just playing with some different stacks

Install DBMS
* https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup?view=sql-server-ver15

Install .net core sdk
* https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro

Creat console application for database migrations (using dbup)
* dotnet new console -o todoMigrations
* cd todoMigrations
* dotnet add package dbup --version 4.2.0
* create scripts folder
* add create table script

Create Web API application
* dotnet new webapi -o todoApi
* http://localhost:5000/todo