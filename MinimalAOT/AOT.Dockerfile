FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.18 AS build
WORKDIR /src
RUN apk update && apk upgrade
RUN apk add --no-cache clang build-base zlib-dev
COPY ["MinimalAOT/MinimalAOT.csproj", "MinimalAOT/"]
RUN dotnet restore "MinimalAOT/MinimalAOT.csproj"
COPY . .
WORKDIR "/src/MinimalAOT"
RUN dotnet build "MinimalAOT.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MinimalAOT.csproj" -c Release -r linux-musl-x64 -o /app

FROM alpine:3.18 AS final
USER $APP_UID
WORKDIR /app
RUN adduser -u 1000 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser
EXPOSE 8080
EXPOSE 8081
COPY --chown=appuser --from=publish /app/MinimalAOT ./MinimalAOT
ENTRYPOINT ["./MinimalAOT"]
