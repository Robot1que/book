# Azure Storage

## Storage Account Types

- **Standard general-purpose v2**: Blob, Queue and Table storage, Azure Files<br/>
Recommended for most scenarios.

- **Premium block blobs**: Blob storage (block blobs and append blobs)<br/>
Recommended for scenarios with high transaction rates, or low storage latency.

- **Premium page blobs**: Page blobs only<br/>
Premium storage account type for page blobs only.

- **Premium file shares**: Page blobs only<br/>
Premium storage account type for file shares only.

Premium account offer higher performance by using solid-state drives.

## Block Blobs Access Tiers

Selecting the right access tier helps to make solution more cost-effective:

- **Hot**: optimised for frequent access.
- **Cool**: optimised for large amounts of data that is infrequently accessed and stored for at least 30 days.
- **Archive**: optimised for data that can tolerate several hours of retrieval latency and will remain in the Archive tier for at least 180 days.

Access tiers can be swithed any time.

## Azure Blob Storage Resource Types

Blob consists of three types of resources:

- **Storage account**: provides unique namespacef for the data.

- **Container**: organises a set of blobs, similar to directory in file system.

- **Blob**: three types of blobs are supported:
  - **Block blobs** - store text or binaty data, up to about 4.7 TB.
  - **Append blobs** - similat to block blobs, but optimised for append operations (like logging data).
  - **Page blobs** - store random access files up to 8 TB in size. Store virtual hard drive (VHD) files and serve as disks for Azure VMs.

## Security Features

All data encrypted at rest by default using Storage Service Encryption (SSE).

Suppots the following access control:
- Azure Active Directory (Azure AD)
- RBAC

For securing data in transit one of the following can be used:
- Client-side Encryption
- HTTPS
- SMB 3.0

OS and dat disks for Azure VMs can be encrypted using Azure Disk Encryption.

Types of encryption keys supported:
- **Microsoft-managed keys**
- **Customer-managed keys**
- **Customer-provided keys** for blob read/write operations.

## Redundancy Options

Redundancy in the primary region:

- **Locally redundant storage (LRS)**: data copied synchronously three times within a single physical location in the primary region.
- **Zone-redundant storage (ZRS)**: data copied synchronously across three Azure availability zones in the primaty region.

Redundancy in the secondary region:

- **Geo-redundant storage (GRS)**:<br/>
    synchronous LRS in the primaty region,<br/>
    then asynchronous copy a single physical location in the secondary region,<br/>
    and then synchronous LRS in the secondary region.
- **Geo-zone-redundant storage (GZRS)**:<br/>
    synchronous ZRS in the primaty region,<br/>
    then asynchronous copy to a single physical location in the secondary region,<br/>
    and then synchronous ZRS in the secondary region.
