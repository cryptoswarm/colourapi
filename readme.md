# Using docker compose to build and run services

Open a terminal, then follow the steps listed below:

1. Create .env file. Add : `MSSQL_SA_PASSWORD=<your strong password` then execute: `source .env`
2. Run `docker-compose up`. This command will build the web api image based on the `dockerfile` and will pull the `mcr.microsoft.com/mssql/server:2019-latest` from docker hub in case it is not present on your system. Eventually, it will create 2 services

# Migrations

1. Install : `dotnet tool install --global dotnet-ef`
2. Add migrations : `dotnet ef migrations add V1__createColourTable`. You do not need to execute this command because the migrations files have already been generated
3. Change the connection string.
   `export ConnectionStrings__ColourApi="Server=localhost,1433;Database=Colours;User Id=sa;Password=<Your strong password>;MultipleActiveResultSets=true"`
4. Execute migrations : `dotnet ef database update`

# Run an SQL Server in docker

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=<your strong password>' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

# Connect to the database in command line using mssql-cli

1. Verify if you have `mssql-cli` by executing : `which mssql-cli`
2. Install `mssql-cli` by executing : `pip install mssql-cli`

mssql-cli -S <server name> -U <user name> -d <database name>

# Connect to the database through docker

1. Run: `docker exec -it colourapi-mssqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P <your strong password>`
