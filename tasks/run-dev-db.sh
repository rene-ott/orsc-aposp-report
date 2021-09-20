#!/bin/bash
cd ..
docker compose -f docker-compose.dev.yml up
read -p "Press any key to resume ..."