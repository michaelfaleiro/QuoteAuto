# Estágio 1: Base para a aplicação final
# Usa a imagem do ASP.NET 9 para rodar a aplicação.
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
WORKDIR /app
EXPOSE 5002

# Estágio 2: Build da aplicação
# Usa o SDK completo do .NET 9 para compilar o projeto.
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia os arquivos .csproj de cada projeto e restaura os pacotes NuGet.
# Isso otimiza o cache do Docker. Se os projetos não mudarem, essa camada não é refeita.
COPY ["src/QuoteAuto.Api/QuoteAuto.Api.csproj", "src/QuoteAuto.Api/"]
COPY ["src/QuoteAuto.Infra/QuoteAuto.Infra.csproj", "src/QuoteAuto.Infra/"]
COPY ["src/QuoteAuto.Application/QuoteAuto.Application.csproj", "src/QuoteAuto.Application/"]
COPY ["src/QuoteAuto.Exceptions/QuoteAuto.Exceptions.csproj", "src/QuoteAuto.Exceptions/"]
COPY ["src/QuoteAuto.Communication/QuoteAuto.Communication.csproj", "src/QuoteAuto.Communication/"]
COPY ["src/QuoteAuto.Core/QuoteAuto.Core.csproj", "src/QuoteAuto.Core/"]
RUN dotnet restore "src/QuoteAuto.Api/QuoteAuto.Api.csproj"

COPY . .

# Compila o projeto
WORKDIR "/src/src/QuoteAuto.Api"
RUN dotnet build "QuoteAuto.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio 3: Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "QuoteAuto.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio 4: Imagem final
# Copia apenas os artefatos publicados para uma imagem limpa e menor.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ponto de entrada para iniciar a aplicação
ENTRYPOINT ["dotnet", "QuoteAuto.Api.dll"]