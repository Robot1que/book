```powershell
az group create `
    --name az204-arm-rg `
    --location uksouth

az deployment group create `
    --resource-group az204-arm-rg `
    --template-file azuredeploy.json `
    --parameters azuredeploy.parameters.json

z storage account show `
    --resource-group az204-arm-rg `
    --name az204storageacc1234

az group delete `
    --name az204-arm-rg `
    --no-wait
```
