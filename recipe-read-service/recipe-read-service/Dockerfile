#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["recipe-read-service/recipe-read-service.csproj", "recipe-read-service/"]
RUN dotnet restore "recipe-read-service/recipe-read-service.csproj"
COPY . .
WORKDIR "/src/recipe-read-service"
RUN dotnet build "recipe-read-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "recipe-read-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "recipe-read-service.dll"]