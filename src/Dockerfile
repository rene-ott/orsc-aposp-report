FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG SKIP_CLIENT_APP_BUILD

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# install NodeJS 14.x
RUN if [ "$SKIP_CLIENT_APP_BUILD" != "True" ]; then \
  echo "Installing NodeJS" && \
  apt-get update -yq && \
  apt-get install curl gnupg -yq && \
  curl -sL https://deb.nodesource.com/setup_14.x | bash - && \
  apt-get install -y nodejs; \
else \
  echo "Skipping NodeJS installation"; \
fi

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
ARG SKIP_CLIENT_APP_BUILD
RUN dotnet publish "ApospReport.API.csproj" -c Release -o /app/publish -p:SkipClientAppBuild=$SKIP_CLIENT_APP_BUILD --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApospReport.API.dll"]