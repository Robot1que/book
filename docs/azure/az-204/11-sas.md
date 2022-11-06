# Shared Access Signatures

## Overview

A shared access signature (SAS) is a signed URI that points to one or more storage resources and includes a token that indicates how the resources may be accessed by the client. One of the query parameters, the signature, is constructed from the SAS parameters and signed with the key that was used to create the SAS. This signature is used by Azure Storage to authenticate access to the storage resource.

## SAS Types

- **User delegation SAS**: secured with Azure Active Directory credentials and also by the permissions specified for the SAS. Applies to Blob storage only. Recommended as a security best practice.
- **Service SAS**: secured with the storage account key. Delegates access to a resource in the following Azure Storage services: Blob storage, Queue storage, Table storage, or Azure Files.
- **Account SAS**: secured with the storage account key. Delegates access to resources in one or more of the storage services. All of the operations available via a service or user delegation SAS are also available via an account SAS.

## Stored Access Policy

The most flexible and secure way to use aa service or account SAS is to associate the SAS tokens with a stored access policy.

Stored access policy groups SAS and provides additional restrictions for signatures that are  bound by the policy like start time, expiry time, permissions, etc.

The following storage resources support stored access policies:

- Blob containers
- File shares
- Queues
- Tables
