# For build and run

```
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
mkdir deploy
cp ./bin/Release/net8.0/win-x64/publish/open-data-gov-ro-mcp.exe ./deploy
cp appsettings.json ./deploy
cd ./deploy
open-data-gov-ro-mcp.exe
```

## Docker build, tag, upload

```
docker tag open-data-gov-ro-mcp-tools radu103/open-data-gov-ro-mcp-tools:latest
docker tag open-data-gov-ro-mcp-tools radu103/open-data-gov-ro-mcp-tools:0.0.1
docker push radu103/open-data-gov-ro-mcp-tools:latest
docker push radu103/open-data-gov-ro-mcp-tools:0.0.1
```