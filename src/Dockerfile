FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ["ApospReport.API/ApospReport.API.csproj", "ApospReport.API/"]
COPY ["ApospReport.Application/ApospReport.Application.csproj", "ApospReport.Application/"]
COPY ["ApospReport.DataStore/ApospReport.DataStore.csproj", "ApospReport.DataStore/"]
COPY ["ApospReport.Contract/ApospReport.Contract.csproj", "ApospReport.Contract/"]
COPY ["ApospReport.Domain/ApospReport.Domain.csproj", "ApospReport.Domain/"]
RUN dotnet restore

COPY . .

WORKDIR "/src/ApospReport.API"
RUN dotnet build "ApospReport.API.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "ApospReport.API.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApospReport.API.dll"]