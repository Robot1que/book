# Step 4: Setup Filebeat

## Overview

Setting up Filebeat consist of the following steps:
- Preparing Filebeat configuration file
- Running cotnainer
- Adding ingest node pipeline (optional)

## Guide

### Configuring Filebeat

Since we will run Filebeat as container it's configuration file needs to be created on a host and then mounted into container.

To create configuration file run:

```bash
cat <<EOF | sudo tee /etc/filebeat/filebeat.docker.yml
output.elasticsearch:
  hosts: ["10.250.0.211:9200"]

logging:
  level: warning
  metrics:
    enabled: false

filebeat.inputs:
- type: container
  paths:
  - /var/lib/docker/containers/*/*.log

processors:
- add_docker_metadata: ~
EOF
```

File above configures Filebeat to:
- Log only warning messages as by default it constantly outputs informational message that can makes reading actual log messages harder.
- Collect messages from Docker container log files.
- Add Docker metadata processor that adds container names to documents (note that by default Container input outputs only container ID).

To verify that configuration file format is correct run:

```bash
docker run \
--rm \
--user=root \
--volume="/etc/filebeat/filebeat.docker.yml:/usr/share/filebeat/filebeat.yml:ro" \
docker.elastic.co/beats/filebeat:7.4.2 \
filebeat test config
```

**NOTE:** it is recommended to run the command above as it also makes sure that path to a config file and mount destination are correct.

Additionally you can export configuration to verify it is configured correctly:

```bash
docker run \
--rm \
--user=root \
--volume="/etc/filebeat/filebeat.docker.yml:/usr/share/filebeat/filebeat.yml:ro" \
docker.elastic.co/beats/filebeat:7.4.2 \
filebeat export config
```

### Starting Container

To start container run:

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

**NOTE:** because we configured logging to not output informational messages `docker logs filebeat` command will not display any log if there are no issues.

More information can be found in the official guidelines:  
[Running Filebeat on Docker](https://www.elastic.co/guide/en/beats/filebeat/current/running-on-docker.html)

### Add Ingest Node Pipelines

Elasticsearch cannot index strings based on string partial content. For example consider the following log message produced by Azure DevOps Agent:
```
Job Job completed with result: Succeeded
```

It is not possible to filter message based on result value - `Succeeded`. To achieve it target portion of a message should be extracted into a separate field. This can be achieved by using [Ingest node](https://www.elastic.co/guide/en/elasticsearch/reference/master/ingest.html).

First, a pipeline has to be created. In free version of Elastic Stack it can be done by using Kibana's [Dev Tools](https://www.elastic.co/guide/en/kibana/current/devtools-kibana.html). In Kibana navigate to Dev Tools and use Console to send the following request to [Ingest REST API](https://www.elastic.co/guide/en/elasticsearch/reference/current/ingest-apis.html):

```json
# PUT _ingest/pipeline/azure-pipeline-agent-log
{
  "description" : "Azure Pipeline Agent Log Analyser",
  "processors" : [
    {
      "grok" : {
        "field" : "message",
        "patterns" : [ "Job %{JOB_TYPE:job.type} completed with result: %{JOB_RESULT:job.result}" ],
        "pattern_definitions" : {
          "JOB_TYPE" : "\\S+",
          "JOB_RESULT" : "\\S+"
        },
        "ignore_failure" : true
      }
    }
  ]
}
```

**NOTE:** to verify that the pipeline has been created successfully you can list all existing pipelines by sending `GET _ingest/pipelines` request.

It uses [Grok processor](https://www.elastic.co/guide/en/elasticsearch/reference/master/grok-processor.html) to extract portions of a text based on Regex-like pattern definitions and puts it into specified fields.

**NOTE:** you can experiment with Grok syntax by opening [Grok Debugger](https://www.elastic.co/guide/en/kibana/current/xpack-grokdebugger.html) in Kibana's Dev Tools.

Second, Filebeat configuration file needs to be updated to start using our new ingest node pipeline:

```yaml
# ...
output.elasticsearch.pipeline: "azure-pipeline-agent-log"
# ...
```

Now incoming messages that satisfy pipeline's pattern will have new `job.type` and `job.result` fields that are indexed and can be used in filters.