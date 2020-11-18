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