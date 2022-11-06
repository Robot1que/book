Get list of locations (UK):
```powershell
az account list-locations -o table | sls uk
```

Get list of supported runtimes for Linux in Azure App Service:
```powershell
az webapp list-runtimes --linux
```