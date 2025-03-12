# DotNet My Platform API

API developed for My Platform app

# Deployment

```sh
# Build the app
dotnet publish -c Release -o ./publish
# Generate zip
cd publish
zip -r ../myapp.zip .
# Deploy to Azure
az webapp deploy --resource-group my-platform-api --name web-my-platform-api --src-path ../myapp.zip
```
