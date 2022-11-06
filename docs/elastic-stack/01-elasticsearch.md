# Step 1: Setup Elasticsearch

## Overview

Deploying Elasticsearch consists of two steps:
- Preparing environment
- Starting a Docker container

To find out information about prerequisites see: [Elastic Stack Overview](00-overview.md)

## Guide

### Prepare Environment

Create a new directory that will persist Elasticseach data for the migration purpose or when upgrading to the next version:

```bash
sudo mkdir --parents /var/lib/elasticsearch/data/
```

Elasticsearch runs as `elasticsearch` user inside a container. That's why owner of newly created directory has to be updated:

```bash
sudo chown --recursive 1000:1000 /var/lib/elasticsearch/
```

### Start Container

To start a container run the following command:
```bash
docker run \
--name es \
--detach \
--restart always \
--network elastic \
--publish 9200:9200 \
--publish 9300:9300 \
--volume /var/lib/elasticsearch/data/:/var/lib/elasticsearch/data/ \
--env "path.data=/var/lib/elasticsearch/data/" \
--env "discovery.type=single-node" \
docker.elastic.co/elasticsearch/elasticsearch:7.4.2
```

Note that Elasticsearch is a distributed engine. To run Elasticsearch on a single node it is important to set `discovery.type=single-node` environment variable.

Make sure Elasticsearch started successfully by verifying it's log:
```bash
docker logs es --follow
```

Once Elasticsearch started it's REST API can be accessed. Check Elasticsearch node information by running:
```bash
curl http://localhost:9200
```

More information can be found in the official guidelines:  
[Install Elasticsearch with Docker](https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html)

---

Next: [Step 2: Setup Kibana](02-kibana.md)