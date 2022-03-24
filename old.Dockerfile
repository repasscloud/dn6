# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./app/publish/ /app
WORKDIR /app
EXPOSE 5000
ENTRYPOINT ["dotnet", "dn6.dll"]
