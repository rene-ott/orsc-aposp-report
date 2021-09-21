#!/bin/bash
cd ..
docker compose -f docker-compose.dev.yml down
rm -rf ./db/var
docker compose -f docker-compose.dev.yml up