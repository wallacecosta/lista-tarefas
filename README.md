# lista-tarefas
API REST - Lista de Tarefas

## Requisitos para executar
Docker

## Detalhes
WebApi em .NET 8 com EF Core, Code First Migrations e banco de dados Sql Server.

## Criar imagem docker aplicação
docker build -t lista-tarefas-api -f Dockerfile .

## Executar
docker compose build
docker compose up -d

[GET] http://localhost:5000/api/tarefas/obter-filtro

[GET] http://localhost:5000/api/tarefas/obter-por-id

[POST] http://localhost:5000/api/tarefas/criar

[PATH] http://localhost:5000/api/tarefas/add-item

[PATH] http://localhost:5000/api/tarefas/concluir-item/{id}

[PATH] http://localhost:5000/api/tarefas/concluir-tarefa/{id}

[DELETE] http://localhost:5000/api/tarefas/excluir-tarefa/{id}

## Endpoints

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/4acf9a82-fe34-4db0-839a-d81f6f14327e)

## Modelos

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/acf37a0b-aa40-42d7-ad34-7a0d163f5250)

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/0eb97638-2d46-4d91-ae45-45b25170bef7)

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/050d418e-7f43-4734-904e-657196eaded0)

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/31930533-1f00-4912-b878-9d9cf03edeb0)

![image](https://github.com/wallacecosta/lista-tarefas/assets/25742247/39cf3437-544e-4683-ba36-b1d796d61b25)

