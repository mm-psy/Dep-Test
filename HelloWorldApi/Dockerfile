# Use the official .NET 8 SDK image for build
FROM mcr.microsoft.com/dotnet/sdk@sha256:0a506ab0c8aa077361af42f82569d364ab1b8741e967955d883e3f23683d473a AS build
WORKDIR /src
COPY . .
RUN dotnet restore --locked-mode
RUN dotnet publish -c Release -o /app/publish --no-restore

# Use the official .NET 8 ASP.NET runtime image for runtime
FROM mcr.microsoft.com/dotnet/aspnet@sha256:d7b25a0c82aac8621a448e396eb8694fefbe8f59fa6189e367a7db1b9d2a65cc AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "HelloWorldApi.dll"]
