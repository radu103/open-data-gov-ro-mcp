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
docker tag open-data-gov-ro-mcp-tools radu103/open-data-gov-ro-mcp-tools:0.0.2
docker push radu103/open-data-gov-ro-mcp-tools:latest
docker push radu103/open-data-gov-ro-mcp-tools:0.0.2
```

## Docker run

Run container with volume mapping from local path:
```
docker run -d -p 21212:21212 --name open-data-gov-ro-mcp-tools1 \
  -e LOCAL_VOLUME_PATH=E:/Work/open-data-gov-ro-mcp/Resources \
  -v E:/Work/open-data-gov-ro-mcp/Resources:/app/build/Resources \
  radu103/open-data-gov-ro-mcp-tools:latest
```

## Using Docker Compose

```
docker-compose up -d
```
