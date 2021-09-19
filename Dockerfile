#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApospReport/ApospReport.csproj", "ApospReport/"]
RUN dotnet restore "ApospReport/ApospReport.csproj"
COPY . .
WORKDIR "/src/ApospReport"
RUN dotnet build "ApospReport.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApospReport.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApospReport.dll"]