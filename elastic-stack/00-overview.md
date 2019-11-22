# Elastic Stack Overview

## Components

Elastic stack consists of multiple components:
- **Elasticsearch** - distributed search engine that includes document based database and REST API.
- **Kibana** - web front-end for viewing, visualising, analysing data.
- **Metricbeat** - collects data about system and sends it to Elasticsearch.
- **Filebeat** - reads data from log files and sends it to Elasticsearch.

## Prerequisites

This guide assumes that Elasticseach and Kibana will be installed on the same Linux Docker host.

### Networking

Create a dedicated network for Elastic Stack apps:

```bash
docker network create --driver bridge elastic
```

---

Next: [Step 1: Setup Elasticsearch](01-elasticsearch.md)