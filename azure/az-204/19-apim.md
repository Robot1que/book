# API Management Service

## Overview

Each API consists of one or more operations, and each API can be added to one or more products. To use API, developers subscribe to a product that contains that API, and then they can call the API's operation, subject to any usage policies that mey be in effect.

The system is made up of the following components:

- **API gateway**: API endpoint.
- **Azure portal**: for administrators to manage APIs.
- **Developer portal**: for developers to learn about APIs, view and call operations, and subscribe to products.

### Products

Products are how APIs are surfaced to developers. Product have one or more APIs, and are configured with a title, description, and terms of use. Products can be:

- **Open**: can be used without subscription.
- **Protected**: must be subscribed to before it can be used.

Subscription approval is configured at the product level and can either require administrator approval, or be auto-approved.

### Groups

Groups are used to manage the visibility of products to developers. API Management has the following immutable system groups:

- **Administrators**: manage API Management service instances, creating the APIs, operations, and products.
- **Developers**: customers that build application using APIs.
- **Guests**: can be granted certain read-only access, such as the ability to view APIs but not call them.

### Developers

Developers represent the user accounts in an API Management service instance. Developers can be created or invited to join by administrators, or they can sign up from the Developer portal. Each developer is a member of one or more groups, and can subscribe to the products that grant visibility to those groups.

### Policies

Allows to change the behavior of the API through configuration. Policies are a collection of statements that are executed sequentially on the request or response of an API.

## API Gateway

![API Gateway](./assets/api-gateway.png)