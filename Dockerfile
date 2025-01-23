FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY UserApi/UserApi.csproj UserApi/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Tests/Tests.csproj Tests/
RUN dotnet restore

COPY . .
WORKDIR /src/UserApi
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserApi.dll"]
