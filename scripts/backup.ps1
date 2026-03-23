Write-Host "📦 Database backup alınıyor..."

docker exec -t postgres_db pg_dump -U website website_db | Out-File -Encoding utf8 db/dumps/latest.sql

Write-Host "✅ Backup tamamlandı: db/dumps/latest.sql"