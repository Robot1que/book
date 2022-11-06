## Start SQL Server

Start SQL Server container:

```bash
docker run \
--name mssql \
--detach \
--env "ACCEPT_EULA=Y" \
--env "MSSQL_SA_PASSWORD=********" \
--env "MSSQL_AGENT_ENABLED=true" \
--env "MSSQL_BACKUP_DIR=/var/opt/mssql/backup/" \
--volume /var/opt/mssql/backup/:/var/opt/mssql/backup/ \
--publish 1433:1433 \
mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04
```

## Restore Backup

List files in backup:

```sql
RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/mydb.bak'
```

Restore backup with new file locations:

```sql
RESTORE
    DATABASE [MyDb]
FROM
    DISK = '/var/opt/mssql/backup/mydb.bak'
WITH
    MOVE 'mydb_sys' TO '/var/opt/mssql/data/mydb_prim.mdf',
    MOVE 'DATA01' TO '/var/opt/mssql/data/mydb_DATA01.MDF',
    MOVE 'INDEX01' TO '/var/opt/mssql/data/mydb_INDEX01.MDF',
    MOVE 'mydb_log' TO '/var/opt/mssql/data/mydb_log.ldf'
```