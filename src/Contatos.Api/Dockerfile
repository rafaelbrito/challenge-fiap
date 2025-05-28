FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia a solução e projetos
COPY FIAP.Fase1.sln ./
COPY src/Contatos.Api/Contatos.Api.csproj src/Contatos.Api/
COPY src/Contatos.Application/Contatos.Application.csproj src/Contatos.Application/
COPY src/Contatos.Core/Contatos.Core.csproj src/Contatos.Core/
COPY src/Contatos.Infra/Contatos.Infra.csproj src/Contatos.Infra/
COPY src/Contatos.Message/Contatos.Message.csproj src/Contatos.Message/
COPY Contatos.Worker/Contatos.Worker.csproj Contatos.Worker/
COPY test/Contatos.Test/Contatos.Test.csproj test/Contatos.Test/

RUN dotnet restore FIAP.Fase1.sln

COPY . .

RUN dotnet publish src/Contatos.Api/Contatos.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Contatos.Api.dll"]
