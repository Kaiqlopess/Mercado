# 1. SDK para compilar e restaurar pacotes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos de projeto (.csproj) para restaurar as dependências
COPY ["src/Mercado.Api/Mercado.Api.csproj", "src/Mercado.Api/"]
COPY ["src/Mercado.Application/Mercado.Application.csproj", "src/Mercado.Application/"]
COPY ["src/Mercado.Domain/Mercado.Domain.csproj", "src/Mercado.Domain/"]
COPY ["src/Mercado.Infra/Mercado.Infra.csproj", "src/Mercado.Infra/"]

# Restaura todas as dependências do NuGet
RUN dotnet restore "src/Mercado.Api/Mercado.Api.csproj"

# Copia todo o código-fonte restante
COPY . .

# Compila a API em modo Release
WORKDIR "/app/src/Mercado.Api"
RUN dotnet publish "Mercado.Api.csproj" -c Release -o /app/out /p:UseAppHost=false

# 2. Imagem final leve (somente o Runtime para rodar)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .

# Configura a porta onde a API vai escutar dentro do container
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

# Executa a DLL principal da sua API
ENTRYPOINT ["dotnet", "Mercado.Api.dll"]

