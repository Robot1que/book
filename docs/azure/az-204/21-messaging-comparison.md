# Messaging Service Comparison

## Event vs. Message

- **Event** - is a lightweight notification of a condition or a state change.

  - The event data has information about what happened but doesn't have the data that triggered the event.
  - The published has no expectation about how the event is handled.

- **Message** - is raw data produced by a service to be consumed or stored elsewhere.

  - The message contains the data that triggered the message pipeline.
  - The published has an expectation about how the consumer handles the message.

## Services

| Service | Purpose | Type | When to use |
|---------|---------|------|-------------|
| Event Grid | Reactive programming | Event distribution (discrete) | React to status changes |
| Event Hubs | Big data pipeline | Event streaming (series) | Telemetry and distributed data streaming |
| Service Bus | High-value enterprise messaging | Message | Order processing and financial transactions |

## Storage Queue vs. Service Bus

| Criteria | Storage queues | Service Bus queues |
|----------|----------------|--------------------|
| Message size | Up to 64KB | Can exceed 64KB |
| Queue size | Can go over 80GB | Up to 80GB |
| Delivery guarantee | At-Least-Once | At-Least-Once or At-Most-Once |
| Ordering guarantee | No | Yes (FIFO) |
| Atomic operation support | No | Yes |
| Receive behavior | Non-blocking | Blocking with or without a timeout |
| Push-style API | No | Yes |
| Exclusive access mode | Lease-based | Lock-based |
| Lease/Lock duration | 30 seconds by default, 7 days maximum | 30 seconds by default |
| Batched receive | Yes | No |
| Batched send | No | Yes |
| AMQP 1.0 support | No | Yes |