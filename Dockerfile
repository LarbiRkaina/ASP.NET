# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar solución y proyectos
COPY book-manager.sln .

# Restaurar (usa rutas relativas)
RUN dotnet restore book-manager.sln

# Copiar TODO el código
COPY . .

# Publicar el proyecto correcto
RUN dotnet publish src/Bookmanager/Bookmanager.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# El .dll se llama como el proyecto: book-manager.dll
ENTRYPOINT ["dotnet", "book-manager.dll"]
