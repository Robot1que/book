```powershell
az group create `
    --name az204-acr-rg `
    --location uksouth

az acr create `
    --resource-group az204-acr-rg `
    --name paAcr1303 `
    --sku Basic

az acr build `
    --registry paAcr1303 `
    --image web-server:1.0.0 `
    --file ./Dockerfile `
    .
```

```powershell
az acr repository list `
    --name paAcr1303 `
    --output table

az acr repository show-tags `
    --name paAcr1303 `
    --repository web-server `
    --output table
```

```powershell
az acr run `
    --registry paAcr1303 `
    --cmd '$Registry/web-server:1.0.0' `
    /dev/null
```

```powershell
az group delete `
    --name az204-acr-rg `
    --yes
```