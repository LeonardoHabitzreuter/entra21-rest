# entra21-rest

## Criando a pasta e o projeto WebAPI
```
md WebAPI
```
```
cd WebAPI
```
```
dotnet new webapi
```

## Para rodar o projeto:
```
dotnet run
```

Recurso: Usuario
## Para obter um recurso da API
#### Retornará TODOS os usuários:
```
GET
https://localhost:5001/users
```

#### Retornará o usuário de ID 1:
```
GET
https://localhost:5001/users/1
```

#### Para criar um novo usuário:
```
POST
https://localhost:5001/users
{
    "name": "Maria",
    "age": 18
}
```

## Banco de dados

### Para rodar o banco de dados
```
docker-compose up
```

### Para conectar no SQL Server através da extensão do SQL Server
localhost
enter
enter
sa
senha
enter
enter

### Instalando bibliotecas para a aplicação conectar no banco de dados
```
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0
```

### Iremos utilizar a ORM EntityFramework
Object
Relational
Mapping

## Queries
### Criar banco de dados
```
CREATE DATABASE Brasileirao
```