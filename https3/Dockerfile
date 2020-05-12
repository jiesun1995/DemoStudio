#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["https3/https3.csproj", "https3/"]
RUN dotnet restore "https3/https3.csproj"
COPY . .
WORKDIR "/src/https3"
RUN dotnet build "https3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "https3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "https3.dll"]