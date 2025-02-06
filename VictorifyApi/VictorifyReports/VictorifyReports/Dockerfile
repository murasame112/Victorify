# Pobieramy bazowy obraz dla środowiska wykonawczego .NET
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

# Instalacja supervisor i innych zależności
RUN apt-get update && apt-get install -y supervisor

# Pobieramy obraz SDK do kompilacji aplikacji
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Kopiujemy plik projektu i przywracamy zależności
COPY ["VictorifyReports.csproj", "."]
RUN dotnet restore "VictorifyReports.csproj"

# Kopiujemy resztę kodu i budujemy aplikację
COPY . .
WORKDIR "/src"
RUN dotnet build "VictorifyReports.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publikujemy aplikację
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VictorifyReports.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Tworzymy obraz końcowy
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Kopiujemy plik konfiguracji supervisor
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf

# Ustawiamy supervisor jako domyślny proces startowy
CMD ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf"]
