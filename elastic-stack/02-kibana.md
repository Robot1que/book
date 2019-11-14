# Step 2: Setup Kibana

## Overview

Deploying Kibana consists of two steps:
- Preparing environment
- Starting a Docker container

To find out information about prerequisites see: [Elastic Stack Overview](00-overview.md)

## Guide

### Preparing Environment

Create a directory for persisting Kibana data between upgrades or for migration:

```bash
sudo mkdir --parents /var/lib/kibana/data/
```

Kibana runs process inside a container as a user with UID `1000`. Therefore that user should be set as an owner of newly created directory:

```bash
sudo chown --recursive 1000:1000 /var/lib/kibana/
```

### Start Container

Start a container by running the following command:

```bash
docker run \
--name kibana \
--detach \
--restart always \
--network elastic \
--publish 5601:5601 \
--volume /var/lib/kibana/data:/var/lib/kibana/data \
--env "ELASTICSEARCH_HOSTS=http://es:9200/" \
--env "PATH_DATA=/var/lib/kibana/data" \
docker.elastic.co/kibana/kibana:7.4.2
```

Attach to Kibana logging to verify that there are no errors:

```bash
docker logs kibana --follow
```

Kibana is ready to be used once you see log message similar to this:
```json
{"type":"log","@timestamp":"2019-11-07T13:37:11Z","tags":["status","plugin:spaces@7.4.2","info"],"pid":8,"state":"green","message":"Status changed from yellow to green - Ready","prevState":"yellow","prevMsg":"Waiting for Elasticsearch"}
```

Finally Kibana can be tested by opening `http://{docker-host}:5601` in a browser.

More information can be found in the official guidelines:  
[Running Kibana on Docker](https://www.elastic.co/guide/en/kibana/current/docker.html)