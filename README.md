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

### Para rodar o banco de dados (desanexanco do terminal)
```
docker-compose up -d
```

### Para parar o container do banco de dados
```
docker-compose down
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

# Docker
Gerencionador de containers

## DockerHub (Parecido com o site do NuGet)
Repositório de imagens

## Docker-compose
Ferramenta para auxiliar a criação de containers em ambiente de DESENVOLVIMENTO

## Image (Parecido com ISO)
Modelo de container

## Container (Parecido com a máquina virtual)
Um sistema operacional que roda apartado dentro da sua máquina
Nós temos um Windows 10, temos um container rodando com Alpine Linux dentro da nossa máquina

### Listar os containers que estão rodando
```
docker container ls
```

### Listar todos os containers
```
docker container ls -a
```

### Remover um container
```
docker container rm <container_id>
```

## Migrations
### Adicionar um novo pacote do EF no projeto Domain
```
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Instalar a cli de migrations como ferramenta global (para ser usado via terminal)
```
dotnet tool install --global dotnet-ef
```

### Rodar a primeira migração (será lido todas as tabelas registradas via DBSet)
```
dotnet ef migrations add InitialCreate
```

### Rodar as migrações (atualizar o banco de dados)
```
dotnet ef database update
```

## Relações
### One-to-many
Relação um para muitos, exemplo:
Um time tem muitos jogadores
