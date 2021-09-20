#!/bin/bash
cd ..

dotnet tool restore

read -p "Enter migration name: " migration_name
dotnet ef migrations --project ./src/ApospReport.DataStore --startup-project ./src/ApospReport.API add $migration_name
read -p "Press any key to resume ..."

