FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["open-data-gov-ro-mcp.csproj", "./"]
RUN dotnet restore "open-data-gov-ro-mcp.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "open-data-gov-ro-mcp.csproj" -c Release -o /app/build --self-contained true /p:PublishSingleFile=true
RUN rm /app/build/appsettings.Development.json
RUN rm /app/build/appsettings.json
COPY ./appsettings.Docker.json /app/build/appsettings.json
RUN rm /app/build/appsettings.Docker.json

# Expose ports - both the HTTP and HTTPS ports from your configuration
EXPOSE 21212

WORKDIR /app/build
RUN mkdir Resources
RUN rm -rf /src
RUN chmod +x ./open-data-gov-ro-mcp

ENTRYPOINT [ "./open-data-gov-ro-mcp" ]