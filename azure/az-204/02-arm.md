# Azure Resource Manager

## Overview

Everything goes through Azure Resource Manager:

![Consistent management layer](./assets/consistent-management-layer.png)

Resource Manager converts deployed template into REST API call to the specific resource provider.

Benefits:
- **Declarative syntax** - entire Azure infrastructure defined declaratively.
- **Repeatable results** - templates are idempotent.
- **Orchestration** - deploys in paraller when possible.

## Template File

Consists of:
- parameters
- variables
- user-defined functions
- resources
- outputs

## Template Specs

Template spec is a resource type for storing an Azure Resource Manager template (ARM template) in Azure for later deployment.

## Conditional Deployment

Conditional deployment doesn't cascade to child resources. Conditional deployment must be applied to each resource.

## Deployment Modes

### Complete Mode

Resources not mentioned in the ARM template will be deleted.

Resources that are excluded because of `condition` are:
- not deleted in version earlier than `2019-05-10`
- are deleted in version `2019-05-10` or later

### Incremental Mode

Resources not mentioned in the ARM temaplate will be left untouched.

Unspecified properties will be overwritten.

### Setting Deployment Mode

```powershell
az deployment group create --mode Complete @otherArgs
```
