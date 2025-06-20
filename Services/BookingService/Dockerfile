# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projeyi kopyala
COPY ["BookingService/BookingService.csproj", "BookingService/"]
# Gerekirse diðer projelere referans da eklenir
RUN dotnet restore "BookingService/BookingService.csproj"

COPY . .
WORKDIR "/src/BookingService"
RUN dotnet build "BookingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingService.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingService.dll"]
