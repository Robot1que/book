# Azure Cache with Redis

## Overview

Azure Cache for Redis provides an in-memory data store based on the Redis software. It's able to process large volumes of application requests by keeping frequently accessed data in the server memory, which can be written to and read from quickly.

Azure Cache for Redis offers both the Redis open-source (OSS Redis) and a commercial product from Redis Labs (Redis Enterprise) as a managed service.

## Service Tiers

Azure Cache for Redis is available in these tiers:

- **Basic** (C0-C6 cache levels):  
runs on a single VM, no SLA. To be used for development and testing.
- **Standard** (C0-C6 cache levels):  
OSS Redis running on two VMs in a replicated configuration.
- **Premium** (P0-P4 cache levels):  
high-performance OSS Redis. Deployed on more powerful VMs compared to the VMs for Basic or Standard caches.
- **Enterprise** (E10, E20, E50, and E100 cache levels):  
high-performance caches powered by Redis Labs' Redis Enterprise software. Supports RediSearch, RedisBloom, and RedisTimeSeries.
- **Enterprise Flash** (F300, F700, and F1500 cache levels):  
cost-effective large caches powered by Redis Labs' Redis Enterprise software. Extends Redis data storage to non-volatile memory, which is cheaper than DRAM, on a VM.

Premium tier allows persisting data in two ways to provide disaster recovery:

- **Redis database (RDB)** persistance takes a periodic snapshot and can rebuild the cache using the snapshot in case of failure.
- **Append only File (AOF)** persistence saves every write operation to a log that is saved at least once per second. This creates bigger files than RDB but has less data loss.

Premium tier allows to implement clustering to automatically split dataset among multiple nodes. Maximum number of shards is 10. The cost incurred is the cost of the original node, multiplied by the number of shards.

## Cache Value Expiration Time

Stale values can be expired by applying a time to live (TTL) value to a key. When the TTL elapses, the key is automatically deleted. Characteristics of TTL:

- Expirations can be set using seconds or milliseconds precision.
- The expire time resolution is always 1 millisecond.
- Information about expires are replicated and persisted on disk, the time virtually passes when your Redis server remains stopped.

## Accessing Cache

A popular high-performance Redis client for the .NET language is [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis). The main connection object is the `StackExchange.Redis.ConnectionMultiplexer`. Create a `ConnectionMultiplexer` instance using the static `ConnectionMultiplexer.Connect` or `ConnectionMultiplexer.ConnectAsync` method, passing in either a connection string or a `ConfigurationOptions` object.
