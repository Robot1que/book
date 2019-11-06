# SETUP NETWORKING
```bash
docker network create --driver bridge elastic
```

# ELASTICSEARCH
```bash
docker run -d --name es --network elastic -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:7.4.1
docker run --name es -v /var/lib/elasticsearch/data/:/var/lib/elasticsearch/data/ -e "path.data=/var/lib/elasticsearch/data/" -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:7.4.1
```

# KIBANA
```bash
docker run -d --name kibana --network elastic -e "ELASTICSEARCH_HOSTS=http://es:9200/" -p 5601:5601 docker.elastic.co/kibana/kibana:7.4.1
docker run --name kibana -v /var/lib/kibana/data:/var/lib/kibana/data -e "ELASTICSEARCH_HOSTS=http://es:9200/" -e "PATH_DATA=/var/lib/kibana/data" -p 5601:5601 docker.elastic.co/kibana/kibana:7.4.1
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