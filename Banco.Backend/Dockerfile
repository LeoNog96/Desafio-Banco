FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /build

COPY Banco.Backend.sln ./

COPY src/Banco.Commons/*.csproj ./src/Banco.Commons/
COPY src/Banco.Domain/*.csproj ./src/Banco.Domain/
COPY src/Banco.Data/*.csproj ./src/Banco.Data/
COPY src/Banco.Application/*.csproj ./src/Banco.Application/
COPY src/Banco.WebApi/*.csproj ./src/Banco.WebApi/

RUN dotnet restore

COPY . .

WORKDIR /build/src/Banco.Commons
RUN dotnet build -c Release -o /app

WORKDIR /build/src/Banco.Domain
RUN dotnet build -c Release -o /app

WORKDIR /build/src/Banco.Data
RUN dotnet build -c Release -o /app

WORKDIR /build/src/Banco.Application
RUN dotnet build -c Release -o /app

WORKDIR /build/src/Banco.WebApi
RUN dotnet build -c Release -o /app

WORKDIR /build
FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Banco.WebApi.dll"] 