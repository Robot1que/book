# Azure App Service

## Overview

Azure App Service is an HTTP-based service for hosting:
- web applications,
- REST API,
- mobile back-end.

Runs natively:
- on Windows,
- on Linux,
- Linux containers.

Features:
- Can scale up/down or scale out/in.
- Continous integration/deployment with Azure DevOps, GitHub, BitBucket, FTP, or a local Git repository on a development machine.
- Deployment slots (only in Standard and Premium plan tiers).

Limitations:
- Shared pricing tier does not support Linux.
- Cannot mix Windoes and Linux apps in the same App Service plan.

## Azure App Service Plans

Each Azure App Service plan defines:
- region,
- number of VMs,
- size of VMs,
- pricing tier.

Pricing tiers:
- **Shared compute**: both **Free** and **Shared** share resource pools with other customers.
- **Dedicated compute**: the **Basic**, **Standard**, **Premium**, **PremiumV2**, and **PremiumV3** tiers run app on dedicated Azure VMs. The hier the tier, the more VM instances are available for scale-out.
- **Isolated**: run dedicated Azure VMs on dedicated Azure Virtual Networks. Provides maximum scale-out capabilities.
- **Consumption**: only available for _function apps_. Scales dynamically depending on workload.

All apps run on all VM instances configured in the App Service plan.

## Manual Deployment

Supports:
- Git
- CLI
- Zip deploy
- FTP/S

## Built-in Authentication

Identity providers:
- Microsoft Identity Platform
- Facebook
- Google
- Twitter

