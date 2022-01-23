# Azure Container Registry

## Tiers

- **Basic** - cost-optimised, storage and throughput most appropriate for lower usage scenarios.
- **Standard** - same as basic, but increased storage and throughput.
- **Premium** - highest amount of storage and concurrent operations. Supports features like geo-replication, content trust for image tag signing, private link with private endpoints to restrict access to the registry.

## Azure  Container Registry Tasks (ACR tasks)

- **Quick task** - build and push iamge to a registry without needing a local Docker engine.
- **Automatically triggered task** - enable triggers to build an image:
  - on source code update,
  - on base image update,
  - on a schedule.
- **Multi-step task** - uses YAML-defined workflows.
