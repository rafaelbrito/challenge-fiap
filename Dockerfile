# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia arquivos de projeto e solução para aproveitar cache
COPY FIAP.Fase1.sln ./
COPY src/ src/
COPY test/ test/

# Restaura dependências da solução
RUN dotnet restore FIAP.Fase1.sln

# Copia todo código (pode ser redundante dependendo do COPY acima, cuidado)
COPY . .

# Publica a API para a pasta /app/publish
RUN dotnet publish src/Contatos.Api/Contatos.Api.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia o build publicado para a pasta /app
COPY --from=build /app/publish .

# Ponto de entrada para rodar a API
ENTRYPOINT ["dotnet", "Contatos.Api.dll"]