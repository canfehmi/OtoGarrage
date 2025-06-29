# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=https://+:5000

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/AuthService/AuthService.csproj", "Services/AuthService/"]
RUN dotnet restore "./Services/AuthService/AuthService.csproj"
COPY . .
WORKDIR "/src/Services/AuthService"
RUN dotnet build "./AuthService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image
FROM build AS publish
RUN dotnet publish "./AuthService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.dll"]
