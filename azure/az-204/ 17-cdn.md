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
