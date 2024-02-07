# Build and run web api docker

1. Build image : `docker build -t colourapi .`
2. Run image : `docker run -d -p 8080:80 colourapi`

# Migrations

1. Install : `dotnet tool install --global dotnet-ef`
2. Add migrations : `dotnet ef migrations add V1__createColourTable`
3. Execute migrations : `dotnet ef database update`

# Run an SQL Server in docker

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<your strong password>' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

# Connect to the database in command line using mssql-cli

1. Verify if you have `mssql-cli` by executing : `which mssql-cli`
2. Install `mssql-cli` by executing : `pip install mssql-cli`

mssql-cli -S <server name> -U <user name> -d <database name>

# Connect to the database through docker

1. Run: `docker exec -it colourapi_mssqlserver_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P <your strong password>`
