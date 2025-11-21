# Use the official .NET 8 SDK image for build
FROM mcr.microsoft.com/dotnet/sdk@sha256:20946c3da829b92ccfccfb9e07ee3490fb78cbf2fbc3d2472eb20651b57dd10c AS build
WORKDIR /src
COPY . .
RUN dotnet restore --locked-mode
RUN dotnet publish -c Release -o /app/publish --no-restore

# Use the official .NET 8 ASP.NET runtime image for runtime
FROM mcr.microsoft.com/dotnet/aspnet@sha256:7c4246c1c384319346d45b3e24a10a21d5b6fc9b36a04790e1588148ff8055b0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "HelloWorldApi.dll"]
