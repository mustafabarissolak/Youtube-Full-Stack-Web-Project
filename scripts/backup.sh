#!/bin/bash

echo "📦 Database backup alınıyor..."

docker exec -t postgres_db pg_dump -U website website_db > db/dumps/latest.sql

echo "✅ Backup tamamlandı: db/dumps/latest.sql"