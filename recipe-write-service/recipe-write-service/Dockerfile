#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["recipe-write-service/recipe-write-service.csproj", "recipe-write-service/"]
RUN dotnet restore "recipe-write-service/recipe-write-service.csproj"
COPY . .
WORKDIR "/src/recipe-write-service"
RUN dotnet build "recipe-write-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "recipe-write-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "recipe-write-service.dll"]