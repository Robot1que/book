# Azure App Configuration

## Overview

Azure App Configuration stores configuration data as key-value pairs and feature flags. Keys are case-sensitive. Same keys can exist with different labels.

## Feature Flags

Feature flags consist of:

- **Feature flag**: a variable with binary state of `on` or `off`.
- **Feature manager**: an application package that handles the lifecycle of all the feature flags in an application.
- **Filter**: a rule for evaluating the state of a feature flag.

## Private Endpoints

Private endpoints can be used for Azure App Configuration to allow clients on a virtual network (VNet) to securely access data over a private link. Network traffic between the clients on the VNet and the App Configuration store traverses over the VNet using a private link on the Microsoft backbone network, eliminating exposure to the public internet.
