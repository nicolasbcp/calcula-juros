#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NicolasPlaisant.CalculaJuros.RetornaTaxa.API/NicolasPlaisant.CalculaJuros.RetornaTaxa.API.csproj", "NicolasPlaisant.CalculaJuros.RetornaTaxa.API/"]
COPY ["NicolasPlaisant.CalculaJuros.Domain.Core/NicolasPlaisant.CalculaJuros.Domain.Core.csproj", "NicolasPlaisant.CalculaJuros.Domain.Core/"]
COPY ["NicolasPlaisant.CalculaJuros.Shared/NicolasPlaisant.CalculaJuros.Shared.csproj", "NicolasPlaisant.CalculaJuros.Shared/"]
COPY ["NicolasPlaisant.CalculaJuros.Crosscutting/NicolasPlaisant.CalculaJuros.Crosscutting.csproj", "NicolasPlaisant.CalculaJuros.Crosscutting/"]
RUN dotnet restore "NicolasPlaisant.CalculaJuros.RetornaTaxa.API/NicolasPlaisant.CalculaJuros.RetornaTaxa.API.csproj"
COPY . .
WORKDIR "/src/NicolasPlaisant.CalculaJuros.RetornaTaxa.API"
RUN dotnet build "NicolasPlaisant.CalculaJuros.RetornaTaxa.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NicolasPlaisant.CalculaJuros.RetornaTaxa.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NicolasPlaisant.CalculaJuros.RetornaTaxa.API.dll"]