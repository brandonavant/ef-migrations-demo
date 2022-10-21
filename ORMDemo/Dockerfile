FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /source

ARG BUILD_CONFIGURATION_ARG

COPY ["src/ORMDemo.API/ORMDemo.API.csproj", "ORMDemo.API/"]
COPY ["ORMDemo.sln", "."]

COPY [".", "."]

RUN dotnet publish -c ${BUILD_CONFIGURATION_ARG} -o /build src/ORMDemo.API/ORMDemo.API.csproj

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app

ARG ASPNETCORE_ENVIRONMENT_ARG

ENV ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT_ARG}
ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80/tcp

COPY --from=build /build .

ENTRYPOINT ["dotnet", "ORMDemo.API.dll"]
