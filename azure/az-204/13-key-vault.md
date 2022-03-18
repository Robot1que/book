# Azure Key Vault

## Overview

Solves the following problems:

- Secret Management
- Key Management
- Certificate Management

Key benefits:

- **Centralized application secrets**: applications can securely access the information they need by using URIs.
- **Securely store secrets and keys**: authentication done via Azure Active Directory.
- **Monitor access and use**: allows to monitor activity by enabling logging for key vault. Azure Key Vault can be configured to:
  - archive to a storage account,
  - stream to an event hub,
  - send the logs to Azure Monitor logs.
- **Simplified administration of application secrets**: Azure Key Vault simplifies securing keys, key life cycle, key storage high availability.

Has two service tiers:
- **Standard tier**: encrypts with software key.
- **Premium tier**: includes hardware security module (HSM)-protected keys.

## Authentication

To do any operations with Key Vault, you first need to authenticate to it. Authentication is done via Azure Active Directory. Authorization may be done via:
- Azure role-based access control (Azure RBAC) - used when dealing with the management of the vaults.
- Key Vault policy - used when attempting to access data stored in a vault.

There are three ways to authenticate to Key Vault:

- **Managed identities to Azure resources**: azure automatically rotates the service principal client secret associated with the identity. Recommended as a best practice.
- **Service principal and certificate**: not recommended as application owner must rotate the certificate.
- **Service principal and secret**: same as service principal and certificate.


## Data Encryption in Transit

Azure Key Vault enforces Transport Layer Security (TLS) protocol to protect data when it's traveling between Azure Kiy Vault and clients.

Perfect Forward Secrecy (PFS) protects connections between customers' client systems and Microsoft cloud services by unique keys.
