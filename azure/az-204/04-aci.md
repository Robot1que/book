# Azure Container Instances

## Container Groups

A container group is a collection of containers that get scheduled in the same host machine. Similar to concept of a pod in Kubernetes, it shares:
- lifecycle,
- resources,
- local network,
- storage cilumes.

![Container group example](./assets/container-groups-example.png)

Multi-container groups currently support only Linux.

There are two common ways to deploy multi-container groups:
- **YAML** - use it when only container instances need to be deployed,
- **ARM template** - use it when other Azure services need to be deployed (like Azure File share).
