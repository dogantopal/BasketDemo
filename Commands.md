##For use dotnet-ef cli
dotnet tool install -g dotnet-ef --version 5.0.4 

##For Create Migration
dotnet ef migrations add InitialCreate -p src/Infrastructure  -o Data/Migrations -s src/API

##For Update Db
It's done automatically when start the project

##For Setup Redis and PostgreSql in local environment
docker-compose up --detach