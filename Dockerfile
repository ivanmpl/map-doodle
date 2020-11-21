FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY MapDoodle.Api/MapDoodle.Api.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish MapDoodle.Api/MapDoodle.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MapDoodle.Api.dll"]
