# DotNet My Platform API

API developed for My Platform app

# Deployment

```
dotnet publish -c Release -o ./publish
cd publish
zip -r ../myapp.zip .
az webapp deployment source config-zip --resource-group MyResourceGroup --name MyUniqueAppName --src ../myapp.zip
```
