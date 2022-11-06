# Microsoft Graph

## Overview

Microsoft Graph is the gateway to data and intelligence in Microsoft 365. It provides access to the data in Microsoft 365, Windows 10, and Enterprise Mobility + Security.

In the Microsoft 365 platform, three main components facilitate the access and flow of data:

- **Microsoft Graph API**: single REST API endpoint `https://graph.microsoft.com`.
- **Microsoft Graph connectors**: work with the incoming direction, delivering **external data to the Microsoft cloud into Microsoft Graph** services and applications.
- **Microsoft Graph Data Connect**: set of tools to streamline secure and scalable **delivery of Microsoft Graph data to popular Azure data stores**.

## REST API

Format:
```
{HTTP method} https://graph.microsoft.com/{version}/{resource}?{query-parameters}
```

Supported versions:
- `v1.0` includes generally available APIs.
- `beta` includes APIs that are currently in preview.

When request returns a lot of data - use `@data.nextLink` URL to page through it.

## SDK

The Microsoft Graph .NET SDK is included in the following NuGet packages:

- `Microsoft.Graph` - contains the models and request builders for accessing the `v1.0` endpoint with the fluent API.
- `Microsoft.Graph.Beta` - contains the models and request builders for accessing the `beta` endpoint with the fluent API.
- `Microsoft.Graph.Core` - core library for making calls to Microsoft Graph.
- `Microsoft.Graph.Auth` - wrapper for MSAL for use with the Microsoft Graph SDK.
