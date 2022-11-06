# Azure Functions

## Overview

Azure Functions is built on the WebJobs SDK.

- **triggers** - way to start execution of the logic.
- **bindings** - way to simplify coding for input and output data.

## Azure Functions and Logic Apps

Both are serveless. Can mix and match.

|   | Azure Functions | Logic Apps |
| - | --------------- | ---------- |
| **Development** | Code-first (imperative ) | Designer-first (declarative) |
| **Monitoring** | Azure Application Insights | Azure portal, Azure Monitor logs |

## App Service WebJobs

Enables to run a program or script in the same instance as a web app (using App Service plan). WebJobs is not yet supported for App Service on Linux.

WebJobs and WebJobs SDK work best together but WebJob can run any program.

## Hosting Options

Any plan requires Azure Storage account to manage triggers and logging functions execution.

Main hosting plans:

- **Consumption plan**: Default hosting plan. Scales automatically. Uses cold start.
- **Functions Premium plan**: Scales automatically. Uses pre-warmed workers. Runs on more powerful instances, and connects to virtual networks.
- **App Service plan**: Runs at regular App Service plan rates. Best for long-running scenarios where Durable Functions can't be used. Allows manual scaling. Auto-scaling is slower then elastic scale of the Premium plan.

Isolated hosting plans:

- **App Service Environment (ASE)**: App Service feature that provides a fully iselated and dedicated environment for securely running App Service apps at high scale.
- **Kubernetes**: isolated and dedicated environment running on top of the Kubernetes platform.

## App Service Always On

**Always on** should be enabled for the App Service plans. Otherwise finctions runtime goes idle after few minutes of inactivity, so only HTTP triggers will "wake up" functions.

## Scaling

Azure Functions uses a component called the **scale controller**. It uses heuristics for each trigger type. The unit of scale is the Function App.

Maximum scale:
- in Consumption plan is 200 instances,
- in Premium plan is 100 instances.

Maximum scale speed:
- for HTTP triggers is once per seconds,
- for non-HTTP triggers is once per 30 seconds.

Scaling is faster in a Premium plan.
