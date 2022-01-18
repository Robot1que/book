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