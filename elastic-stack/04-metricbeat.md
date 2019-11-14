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