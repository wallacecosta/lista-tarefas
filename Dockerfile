FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

EXPOSE 80

WORKDIR /app

ENV DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0

COPY /ListaTarefas.sln /app/ListaTarefas.sln
COPY /src/ListaTarefas.API/ListaTarefas.API.csproj /app/src/ListaTarefas.API/ListaTarefas.API.csproj
COPY /src/ListaTarefas.Domain/ListaTarefas.Domain.csproj /app/src/ListaTarefas.Domain/ListaTarefas.Domain.csproj
COPY /src/ListaTarefas.Repositories/ListaTarefas.Repositories.csproj /app/src/ListaTarefas.Repositories/ListaTarefas.Repositories.csproj

RUN dotnet restore --no-cache

COPY . .

RUN dotnet build \
    && dotnet publish -c Release -o /build

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /build ./

ENTRYPOINT ["dotnet", "./ListaTarefas.API.dll"]