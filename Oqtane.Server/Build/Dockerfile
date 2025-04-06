#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_HTTP_PORTS=8080
ENV ASPNETCORE_ENVIRONMENT=Production

#Build MySqlConnector
FROM mcr.microsoft.com/dotnet/sdk:9.0.100 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
ARG GITHUB_MYSQLCONNECTOR_RELEASE_URL=https://github.com/mysql-net/MySqlConnector/archive/refs/tags/2.4.0.zip
RUN apt-get update && apt-get install -y unzip
RUN curl -L $GITHUB_MYSQLCONNECTOR_RELEASE_URL -o release.zip
RUN trap `unzip -q release.zip`
RUN dotnet restore "./MySqlConnector-2.4.0/src/MySqlConnector/MySqlConnector.csproj"
COPY . .
WORKDIR "/src/MySqlConnector-2.4.0/src/MySqlConnector"
RUN dotnet build "./MySqlConnector.csproj" -c $BUILD_CONFIGURATION --framework net9.0 -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/MySqlConnector-2.4.0/src/MySqlConnector"
RUN dotnet publish "./MySqlConnector.csproj" -c $BUILD_CONFIGURATION --framework net9.0 -o /app/publish /p:UseAppHost=false

#Framework
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS download
WORKDIR /src
ARG GITHUB_RELEASE_URL=https://github.com/oqtane/oqtane.framework/releases/download/v6.1.1/Oqtane.Framework.6.1.1.Install.zip
RUN apt-get update && apt-get install -y unzip
RUN curl -L $GITHUB_RELEASE_URL -o release.zip
RUN trap `unzip -q release.zip -d /app`

#Packages
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS packages
WORKDIR /Packages
ARG GITHUB_BOOTSWATCH_URL=https://github.com/oqtane/oqtane.theme.bootswatch/releases/download/v6.0.1/Oqtane.Theme.Bootswatch.6.0.1.nupkg
RUN curl -OL $GITHUB_BOOTSWATCH_URL -o .

FROM base AS final
COPY --from=download /app ./
COPY --from=publish /app/publish/MySqlConnector.dll .
COPY --from=packages /Packages ./Packages
RUN chown -R app:app /app
RUN find /app -type d -exec chmod u+x {} +
USER app
ENTRYPOINT ["dotnet", "Oqtane.Server.dll"]