# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY *.sln .
COPY **/*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish book-manager.sln -c Release -o /app/publish --no-restore

# Etapa 2: Runtime (más pequeña)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "book-manager.dll"]
