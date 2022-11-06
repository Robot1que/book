# Managed Identities

## Overview

Provides an identity for applications to use when connection to resources that support Azure Active Directory (Azure AD) authentication.

There are two types of managed identities:

- **System-assigned managed identity**: when enabled, Azure creates an identity for the instance in the Azure AD tenant that's trusted by the subscription of the instance. After created, the credentials are provisioned onto the instance. The lifecycle of a system-assigned identity is directly tied to the Azure service instance that it's enabled on. When the instance is deleted, Azure automatically cleans up the credentials and the identity in Azure AD.
- **User-assigned managed identity**: created as a standalone Azure resource. Trusted by subscription in use. After the identity is created, the identity can be assigned to one or more Azure service instances. The lifecycle of a user-assigned identity is managed separately from the lifecycle of the Azure service instances to which it's assigned.

## Requesting Access Token

To get an access token, a request to the Azure Instance Metadata Service (IMDS) endpoint needs to be sent with HTTP header `Metadata: true`:
```
GET http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://management.azure.com/
```
