FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости (кэш слоёв)
COPY src/MyApp/MyApp.csproj ./MyApp/
RUN dotnet restore ./MyApp/MyApp.csproj


# Копируем весь исходник
COPY src/MyApp/ ./MyApp/
WORKDIR /app/MyApp
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Переменные окружения для ASP.NET
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

# Аналог твоих команд: dotnet build + dotnet run
CMD ["sh", "-c", "dotnet build && dotnet run --no-build --urls http://+:8080"]