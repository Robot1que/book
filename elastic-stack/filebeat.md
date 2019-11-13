# FILEBEAT

Configuration example:
```yaml
output.elasticsearch:
  hosts: ["10.250.0.211:9200"]

processors:
- add_docker_metadata: ~

filebeat.inputs:
- type: container
  paths:
  - /var/lib/docker/containers/*/*.log
```

Export configuration to verify path has been set correctly and values:

```bash
docker run \
--rm \
--user=root \
--volume="/etc/filebeat/filebeat.docker.yml:/usr/share/filebeat/filebeat.yml:ro" \
docker.elastic.co/beats/filebeat:7.4.2 \
filebeat export config
```

Test configuration:

```bash
docker run \
--rm \
--user=root \
--volume="/etc/filebeat/filebeat.docker.yml:/usr/share/filebeat/filebeat.yml:ro" \
docker.elastic.co/beats/filebeat:7.4.2 \
filebeat test config
```

Start container:

```bash
docker run \
--name=filebeat \
--detach \
--user=root \
--volume="/etc/filebeat/filebeat.docker.yml:/usr/share/filebeat/filebeat.yml:ro" \
--volume="/var/lib/docker/containers:/var/lib/docker/containers:ro" \
--volume="/var/run/docker.sock:/var/run/docker.sock:ro" \
docker.elastic.co/beats/filebeat:7.4.2 \
filebeat -e -strict.perms=false
```

docker run \
--rm \
--name=filebeat \
--user=root \
--volume="/etc/filebeat/filebeat.docker.yml:/usr/share/filebeat/filebeat.yml:ro" \
--volume="/var/lib/docker/containers:/var/lib/docker/containers:ro" \
--volume="/var/run/docker.sock:/var/run/docker.sock:ro" \
docker.elastic.co/beats/filebeat:7.4.2 \
filebeat -e -strict.perms=false