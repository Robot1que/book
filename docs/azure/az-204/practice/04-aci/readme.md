```powershell
az group create `
    --name az204-aci-rg `
    --location uksouth
```

```powershell
$DNS_NAME_LABEL = "pa-aci-test"

az container create `
    --resource-group az204-aci-rg `
    --name mycontainer `
    --image nginx `
    --port 80 `
    --dns-name-label $DNS_NAME_LABEL `
    --location uksouth

az container show `
    --resource-group az204-aci-rg `
    --name mycontainer `
    --query "{FQDN:ipAddress.fqdn,State:provisioningState}" `
    --output table
```

```powershell
az group delete `
    --name az204-aci-rg `
    --yes
```
