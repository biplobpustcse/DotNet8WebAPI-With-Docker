# Dot Net 8 Web API With Docker

#### Docker File

```
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DotNet8WebAPI/DotNet8WebAPI.csproj", "DotNet8WebAPI/"]
RUN dotnet restore "./DotNet8WebAPI/./DotNet8WebAPI.csproj"
COPY . .
WORKDIR "/src/DotNet8WebAPI"
RUN dotnet build "./DotNet8WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotNet8WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet8WebAPI.dll"]
```

#### Instead, go to the parent directory, with the .sln file and use the docker -f option to specify the Dockerfile to use in the subfolder:
#### Create image
```
docker build -t counter-image -f DotNet8WebAPI/Dockerfile .
```
#### It worked for me.
#### Create container
```
docker run -p 4201:8080 --name your-container-name your-image-name
```
