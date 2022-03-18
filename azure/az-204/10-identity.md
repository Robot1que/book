# Microsoft Identity Platform

## Overview

Offers features like passwordless authentication, step-up authentication, and Conditional Access.

Consists of:
- **OAuth 2.0 and OpenID Connect standard-compliant authentication service**: allows developers to authenticate several identity types, including:
  - Work or School accounts, provisioned by Azure Active Directory
  - Personal Microsoft account
  - Social and local accounts, by using Azure Active Directory B2C
- **Open-source libraries**: Microsoft Authentication Libraries (MSAL) and support for other standards-compliant libraries.
- **Application management portal**: registration and configuration experience in the Azure portal, along with other Azure management capabilities.
- **Application configuration API and PowerShell**: programmatic configuration of application through the Microsoft Graph API and PowerShell.

## Application Object

First, an application must be registered with Azure Active Directory. Application can be:

- **single tenant**: only accessible in your tenant.
- **multi-tenant**: accessible in other tenants.

Application object is registered in a single Azure Active Directory tenant, a.k.a. "home" tenant. An application object is used as a blueprint or a template for one or more service principal objects. A service principal is used in every tenant where the application is used.

Application object describes three aspects of an application:

- how the service can issue tokens in order to access the application,
- resources that the application might need to access,
- and the actions that the application can take.

## Service Principals

To access resources entity must be represented by security principal. This is true for both - users (user principal) and applications (service principal).

There are three types of service principals:

- **Application** - local representation of a global application object.
- **Managed identity** - represents managed identity.
- **Legacy** - represents a legacy app, which is an app created before app registrations were introduced or an app created through legacy experiences. Can only be used in the tenant where it was created.

## Permission Types

Microsoft identity platform supports two types of permissions:

- **Delegated permissions**: used by apps that have a signed-in user present. The app is delegated with the permission to act as a signed-in user when it makes calls to the target resource. The user or an administrator can consent to the permissions that the ap requests.
- **Application permissions**: used by apps that run without a signed-in user present, for example, apps that run as a background services or daemons. Only administrator can consent to application permissions.

## Consent Types

Applications in Microsoft identity platform rely in consent in order to gain access to necessary resources or APIs. There are three consent types:

- **Static user consent**: all the permissions need to be specified in the app's configuration in the Azure portal. Of the user has not grand=ted consent for this app, then Microsoft identity platform will prompt the user to provide consent at this time. Administrators can consent on behalf of all users in the organization.
- **Incremental and dynamic user consent**: ask for minimum set of permissions upfront and request more over time as the customer uses additional app features. If user hasn't yet consented to new scopes added to the request, they'll be prompted to consent only to the new permissions. Only applies to delegated permissions and not to application permissions.
- **Admin consent**: is required when your app needs access to certain high-privilege permissions.

## Conditional Access

Enables developers and enterprise customers to protect services in a multitude of ways including:

- multifactor authentication,
- allowing only Intune enrolled devices to access specific services,
- restricting user locations and IP ranges.

The following scenarios require code to handle Conditional Access challenges:

- apps performing the on-behalf-of flow,
- apps accessing multiple services/resources,
- single-page apps using `MSAL.js`,
- web apps calling a resource.

## Application Types

Applications tend to separate into the following categories:

- **public client applications**: apps that run on devices or desktop computers, or in a web browser. They're not trusted to safely keep application secrets and support only public client flows.
- **confidential client applications**: apps that run on servers. They're considered difficult to access, and for that reason capable of keeping an application secret.

