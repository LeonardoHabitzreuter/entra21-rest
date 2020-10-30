# entra21-rest

## Criando um novo projeto WebAPI
```
dotnet new webapi
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