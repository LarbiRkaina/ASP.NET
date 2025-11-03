# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia TODO (incluye .sln y todos los .csproj)
COPY . .

# Restaura (ahora sí encuentra todo)
RUN dotnet restore book-manager.sln

# Publica
RUN dotnet publish book-manager.sln -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "book-manager.dll"]
