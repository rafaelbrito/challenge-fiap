# Usar a imagem base do .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagem para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar a solu��o e os arquivos de projeto
COPY ["FIAP.Fase1.sln", "FIAP.Fase1.sln"]
COPY ["src/Contatos.Api/Contatos.Api.csproj", "src/Contatos.Api/"]
COPY ["src/Contatos.Application/Contatos.Application.csproj", "src/Contatos.Application/"]
COPY ["src/Contatos.Core/Contatos.Core.csproj", "src/Contatos.Core/"]
COPY ["src/Contatos.Infra/Contatos.Infra.csproj", "src/Contatos.Infra/"]

# Restaurar as depend�ncias de todos os projetos
RUN dotnet restore "FIAP.Fase1.sln"

# Copiar o restante do c�digo
COPY . .

# Compilar a aplica��o
WORKDIR "/src/Contatos.Api"  # Corrigido para o diret�rio correto
RUN dotnet build "Contatos.Api.csproj" -c Release -o /app/build

# Publicar a aplica��o
FROM build AS publish
RUN dotnet publish "Contatos.Api.csproj" -c Release -o /app/publish

# Imagem para a execu��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Definir o ponto de entrada para a aplica��o
ENTRYPOINT ["dotnet", "Contatos.Api.dll"]
