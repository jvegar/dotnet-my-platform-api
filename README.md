# DotNet My Platform API

API developed for My Platform app

# Deployment

```
dotnet publish -c Release -o ./publish
cd publish
zip -r ../myapp.zip .
az webapp deploy --resource-group my-platform-api --name web-my-platform-api --src-path ../myapp.zi
```
