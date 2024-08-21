# Stage 1: Base Image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app

# Expose ports
EXPOSE 8080
EXPOSE 8081

# Stage 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release  
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["Tariff.Api/Tariff.Api.csproj", "Tariff.Api/"]
COPY ["Tariff.ApplicationService/Tariff.ApplicationService.csproj", "Tariff.ApplicationService/"]
COPY ["Tariff.Core/Tariff.Core.csproj", "Tariff.Core/"]
COPY ["Tariff.Provider/Tariff.Provider.csproj", "Tariff.Provider/"]
RUN dotnet restore "Tariff.Api/Tariff.Api.csproj"

# Copy the rest of the files and build
COPY . .
WORKDIR "/src/Tariff.Api"
RUN dotnet build "Tariff.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tariff.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Stage 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point
ENTRYPOINT ["dotnet", "Tariff.Api.dll"]


