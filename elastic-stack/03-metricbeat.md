# Step 3: Setup Metricbeat

## Overview

Metricbeat can be installed as an APT package. Setup consists of multiple steps:
- Registering Elastic package repository
- Installing Metricbeat package
- Configuring Metricbeat
- Starting Metricbeat daemon

## Guide

### Install APT package

Install secure APT transport:

```bash
sudo apt-get install apt-transport-https
```

Register key to trust Elastic packages:

```bash
wget -qO - https://artifacts.elastic.co/GPG-KEY-elasticsearch | sudo apt-key add -
```

Register Elastic package repository:

```bash
echo "deb https://artifacts.elastic.co/packages/7.x/apt stable main" | sudo tee -a /etc/apt/sources.list.d/elastic-7.x.list
```

Update package list and install Metricbeat package:

```bash
sudo apt-get update && sudo apt-get install metricbeat
```

Enable Metricbeat daemon to start automatically after reboot:

```bash
sudo systemctl enable metricbeat
```

More information can be found in the official guidelines:  
[Repositories for APT and YUM](https://www.elastic.co/guide/en/beats/metricbeat/current/setup-repositories.html)

### Configure Metricbeat

Change Metricbeat daemon configuration file:

```bash
sudo nano /etc/metricbeat/metricbeat.yml
```

Metricbeat supports different modules whose configuration files are located in `/etc/metricbeat/modules.d` directory. For example `system` module collects data about host system, while `docker` module collects data about running containers.

Configure `system` module to make sure it sends required data:

```bash
sudo nano /etc/metricbeat/modules.d/system.yml
```

Enable `docker` module:

```bash
sudo metricbeat modules enable docker
```

To verify list of enabled Metricbeat modules run:

```bash
sudo metricbeat modules list
```

To change `docker` Metricbeat module configuration file run:

```bash
sudo nano /etc/metricbeat/modules.d/docker.yml
```

To read more about Metricbeat modules go to:
[Metricbeat Modules](https://www.elastic.co/guide/en/beats/metricbeat/current/metricbeat-modules.html)

### Start Metricbeat daemon

Once required configuration has been updated Metricbeat daemon is ready to be started:

```bash
sudo systemctl start metricbeat
```

Verify status of running Metricbeat daemon and make sure there are no outstanding errors:

```bash
sudo systemctl status metricbeat
```