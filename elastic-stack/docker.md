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
--restart always \
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

More information can be found in the official guidelines:  
[Install Elasticsearch with Docker](https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html)

# KIBANA

Create a directory for persisting Kibana data between upgrades:
```bash
sudo mkdir --parents /var/lib/kibana/data/
```

Kibana runs process as a user with UID `1000` inside a container. Therefore that user should be set as an owner of new directory:
```bash
sudo chown --recursive 1000:1000 /var/lib/kibana/
```

Now preparations are complete and container is ready to be started:
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

Finally Kibana can be tested by opening `http://docker-host:5601` in a browser.

More information can be found in the official guidelines:  
[Running Kibana on Docker](https://www.elastic.co/guide/en/kibana/current/docker.html)

# METRICBEAT

## Install APT package

```bash
wget -qO - https://artifacts.elastic.co/GPG-KEY-elasticsearch | sudo apt-key add -
```

```bash
sudo apt-get install apt-transport-https
```

```bash
echo "deb https://artifacts.elastic.co/packages/7.x/apt stable main" | sudo tee -a /etc/apt/sources.list.d/elastic-7.x.list
```

```bash
sudo apt-get update && sudo apt-get install metricbeat
```

```bash
sudo systemctl enable metricbeat
```

More information can be found in the official guidelines:  
[Repositories for APT and YUM](https://www.elastic.co/guide/en/beats/metricbeat/current/setup-repositories.html)

## Configuration

```bash
sudo nano /etc/metricbeat/metricbeat.yml
```

```bash
sudo nano /etc/metricbeat/modules.d/system.yml
```

```bash
sudo metricbeat modules enable docker
```

```bash
sudo nano /etc/metricbeat/modules.d/docker.yml
```