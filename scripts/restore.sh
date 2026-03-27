#!/bin/bash

dotnet restore

dotnet build

echo "Containerlar başlatılıyor..."

docker compose up -d

echo "DB hazır olması bekleniyor..."
sleep 5

echo "Backup geri yükleniyor..."

cat db/dumps/latest.sql | docker exec -i postgres_db psql -U website -d website_db

echo "Database hazır!"