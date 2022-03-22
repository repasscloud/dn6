#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dn6.csproj", "./"]
RUN dotnet restore "dn6.csproj"
COPY ["./", ",/"]
RUN dotnet build "dn6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dn6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dn6.dll"]
