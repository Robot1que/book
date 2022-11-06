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

## Azure Blob Storage Resource Types

Blob consists of three types of resources:

- **Storage account**: provides unique namespace for the data.

- **Container**: organises a set of blobs, similar to directory in file system.

- **Blob**: three types of blobs are supported:
  - **Block blobs** - store text or binary data, up to about 4.7 TB.
  - **Append blobs** - similar to block blobs, but optimised for append operations (like logging data).
  - **Page blobs** - store random access files up to 8 TB in size. Store virtual hard drive (VHD) files and serve as disks for Azure VMs.

## Security Features

All data encrypted at rest by default using Storage Service Encryption (SSE).

Supports the following access control:
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
- **Zone-redundant storage (ZRS)**: data copied synchronously across three Azure availability zones in the primary region.

Redundancy in the secondary region:

- **Geo-redundant storage (GRS)**:<br/>
    synchronous LRS in the primary region,<br/>
    then asynchronous copy a single physical location in the secondary region,<br/>
    and then synchronous LRS in the secondary region.
- **Geo-zone-redundant storage (GZRS)**:<br/>
    synchronous ZRS in the primary region,<br/>
    then asynchronous copy to a single physical location in the secondary region,<br/>
    and then synchronous ZRS in the secondary region.

## Block Blobs Access Tiers

Selecting the right access tier helps to make solution more cost-effective. Access tiers can be switched any time.

- **Hot** (online): optimised for frequent access.
- **Cool** (online): optimised for large amounts of data that is infrequently accessed and stored for at least 30 days.
- **Archive** (offline): optimised for data that can tolerate several hours of retrieval latency and will remain in the Archive tier for at least 180 days.

Scenarios:

- Transition blobs to a cooler storage tier to optimise for performance and cost.
- Delete blobs at the end of their lifecycles.
- Define rules to be run once per day at the storage account level.
- Apply rules to containers or a subset of blobs (using prefixes as filters).

## Blob Storage Lifecycle Policies

Rule actions:

- `tierToCool`
- `enableAutoTierToHotFromCool`
- `tierToArchive`
- `delete`

When multiple actions are applicable, lifecycle management applies the least expensive action to the blob.

Rule action conditions:

- `daysAfterModificationGreaterThan`
- `daysAfterCreationGreaterThan`

Example:
```json
{
  "rules": [
    {
      "enabled": true,
      "name": "move-to-cool",
      "type": "Lifecycle",
      "definition": {
        "actions": {
          "baseBlob": {
            "tierToCool": {
              "daysAfterModificationGreaterThan": 30
            }
          }
        },
        "filters": {
          "blobTypes": [ "blockBlob" ],
          "prefixMatch": [ "sample-container/log" ]
        }
      }
    }
  ]
}
```

## Blob Data Rehydration From Archive Tier

Rehydration can be done in either of two ways:

- Copy an archived blob to an online tier by using **copy blob** or **copy blob from URL** operation.
- Change a blob's access tier to an online tier by using **set blob tier** operation.

Rehydration priority can be set by using `x-ms-rehydrate-priority` header. Options include:

- **Standard priority**
  - request will be processed in the order it was received
  - may take up to 15 hours.
- **High priority**
  - request will be prioritised over standard priority
  - may complete in under 1 hour for objects under 10 GB in size.

## Preperties and Metadata

Blob containers support:
- **System properties**: exist on each blob storage resource. Some can be read or set, while others are read-only.
- **User-defined metadata**: name/value pairs that are valid HTTP header, so should adhere to all restrictions governing HTTP headers.
