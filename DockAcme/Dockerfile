# Imagen base de .NET SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DockAcme.csproj", "./"]
RUN dotnet restore "DockAcme.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "DockAcme.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockAcme.csproj" -c Release -o /app/publish

# Imagen base para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copiar la aplicación publicada
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DockAcme.dll"]
