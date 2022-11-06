# Azure Content Delivery Network (CDN)

## Overview

Allows to efficiently deliver content by caching it on edge servers in point-of-presence (POP) locations. Also can accelerate dynamic content, which cannot be cached, by leveraging various network optimizations using CDN POPs. For example, route optimization to bypass Border Gateway Protocol (BGP).

To use Azure CDN at least one CDN profile needs to be created, which is a collection of CDN endpoints. Every CDN endpoint represents a specific configuration of content deliver behavior and access. Multiple profiles can be used to organize CDN endpoints by internet domain, web application, or some other criteria.

Azure CDN pricing is applied at the CDN profile level.

Azure CDN includes four products:

- Azure CDN Standard from Microsoft
- Azure CDN Standard from Akamai
- Azure CDN Standard from Verizon
- Azure CDN Premium from Verizon

## Limitations

Each Azure subscription has default limits for the following resources:

- the number of CDN profiles that can be created,
- the number of endpoints that can be created in a CDN profile,
- the number of custom domains that can be mapped to an endpoint.

## Caching Behavior

Caching rules in Azure CDN Standard for Microsoft are set at the endpoint level and provide three configuration options:

- **Ignore query strings**: default mode. Passes the request and any query strings directly to the origin server on the first request and caches the asset. New requests for the same asset will ignore any query strings until the TTL expires.

- **Bypass caching for query strings**: each query request from the client is passed directly to the origin server with no caching.

- **Cache every unique URL**: every unique URL is passed back to the origin server and the response cached with its own TTL.

Other tiers provide additional configuration options, which include:

- **Caching rules**: can be either global (apply to all content from a specified endpoint) or custom (apply to specific paths and file extensions).

- **Query string caching**: configures how Azure CDN responds to a query string (see rules above). Query string caching has no effect on files that can't be cached.

## Time To Live (TTL)

The `Cache-Control` header contained in the HTTP response from origin server determines the TTL duration.

Azure CDN default TTL values:

- General web delivery optimizations: 7 days.
- Large file optimizations: 1 day.
- Media streaming optimizations: 1 year.

## Content Updating

Cached content can be purged from the edge nodes, which refreshes the content on the next client request. It can be done in several ways:

- On an endpoint by endpoint basis, or all endpoints simultaneously.
- Specify a file, by including the path to that file or all assets on the selected endpoint by checking the *Purge All* checkbox in the Azure portal.
- Based on wildcards (*) or using the root (/).

Azure CLI allows to purge cache with the following command:
```sh
az cdn endpoint purge <params>
```

Additionally assets can be preloaded with:
```sh
az cdn endpoint load <params>
```

## Geo-filtering

Content in specific countries can be allowed or blocked with geo-filtering, based on the country code. In the Azure CDN Standard for Microsoft Tier, only entire site can be allowed or blocked. With the Verizon and Akamai tiers, restrictions can be set up on directory paths.

## Interact with Azure CDN by using .NET

Install `Microsoft.Azure.Management.Cdn.Fluent` NuGet package and use `CdnManagementClient` class.
