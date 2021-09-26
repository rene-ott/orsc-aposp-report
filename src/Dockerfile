FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# install NodeJS 14.x
# see https://github.com/nodesource/distributions/blob/master/README.md#deb
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs

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