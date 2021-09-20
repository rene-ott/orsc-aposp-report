#!/bin/bash
cd ..

dotnet tool restore

read -p "Enter migration name (InitialCreate):" migration_name

if [ -z "$migration_name" ];
then
	rm -rf ./src/ApospReport.DataStore/Migrations
	migration_name='InitialCreate'
fi

dotnet ef migrations --project ./src/ApospReport.DataStore --startup-project ./src/ApospReport.API add $migration_name
dotnet ef migrations --project ./src/ApospReport.DataStore --startup-project ./src/ApospReport.API script -i -o ./src/ApospReport.DataStore/Migrations/script.sql
read -p "Press any key to resume ..."

