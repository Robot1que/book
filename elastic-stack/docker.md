# SETUP NETWORKING

Create a dedicated network for Elastic Stack apps:
```bash
docker network create --driver bridge elastic
```

# ELASTICSEARCH

Before starting container create a folder that will persist ElasticSeach data:
```bash
sudo mkdir --parents /var/lib/elasticsearch/data/
```

ElasticSearch run as `elasticseach` user inside a container. That's why we need to change owner of newly created folder:
```bash
sudo chown --recursive 1000:1000 /var/lib/elasticsearch/
```

Finally to start a container run the following command:
```bash
docker run \
--name es \
--detach \
--network elastic \
--publish 9200:9200 \
--publish 9300:9300 \
--volume /var/lib/elasticsearch/data/:/var/lib/elasticsearch/data/ \
--env "path.data=/var/lib/elasticsearch/data/" \
--env "discovery.type=single-node" \
docker.elastic.co/elasticsearch/elasticsearch:7.4.2
```

Make sure ElasticSearch started successfully by reading it's log:
```bash
docker logs es --follow
```

Once ElasticSearch started you can access it's REST API and check node information by running:
```bash
curl http://localhost:9200
```

To find more information read the official guidelines:  
[Install Elasticsearch with Docker](https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html)

# KIBANA

```bash
sudo mkdir --parents /var/lib/kibana/data/
```

```bash
sudo chown --recursive 1000:1000 /var/lib/kibana/
```

```bash
docker run \
--name kibana \
--detach \
--network elastic \
--publish 5601:5601 \
--volume /var/lib/kibana/data:/var/lib/kibana/data \
--env "ELASTICSEARCH_HOSTS=http://es:9200/" \
--env "PATH_DATA=/var/lib/kibana/data" \
docker.elastic.co/kibana/kibana:7.4.2
```

```bash
docker logs kibana --follow
```

# METRICBEAT
Create the index pattern and load visualizations, dashboards, and machine learning jobs
```bash
docker run --name filebeat docker.elastic.co/beats/filebeat:7.4.1 setup -E setup.kibana.host=172.17.0.3:5601 -E output.elasticsearch.hosts=["172.17.0.2:9200"]
docker run -d --name filebeat --user=root -v "$(pwd)/filebeat.yml:/usr/share/filebeat/filebeat.yml:ro" -v "/var/lib/docker/containers:/var/lib/docker/containers:ro" -v "/var/run/docker.sock:/var/run/docker.sock:ro" docker.elastic.co/beats/filebeat:7.4.1 filebeat -e -strict.perms=false -E output.elasticsearch.hosts=["172.17.0.2:9200"]
```

# GRAFANA
```bash
docker run -d --name grafana -p 3000:3000 grafana/grafana:6.4.3
# Cred: admin / admin
```

```
docker stats --format "table {{.CPUPerc}}\t{{.MemUsage}}\t{{.MemPerc}}\t{{.Name}}"
```
