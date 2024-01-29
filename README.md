# lista-tarefas
API REST - Lista de Tarefas

## Requisitos para executar
Docker

## Detalhes
WebApi em .NET 8 com EF Core, Code First Migrations e banco de dados Sql Server.

## Criar imagem docker aplicação
docker build -t lista-tarefas-api -f Dockerfile .

## Executar

### Docker
docker compose build

docker compose up -d

## Endpoints

[GET] http://localhost:5000/api/tarefas/obter-filtro

[GET] http://localhost:5000/api/tarefas/obter-por-id

[POST] http://localhost:5000/api/tarefas/criar

[PATH] http://localhost:5000/api/tarefas/add-item

[PATH] http://localhost:5000/api/tarefas/concluir-item/{id}

[PATH] http://localhost:5000/api/tarefas/concluir-tarefa/{id}

[DELETE] http://localhost:5000/api/tarefas/excluir-tarefa/{id}

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/4acf9a82-fe34-4db0-839a-d81f6f14327e)
