Write-Host "Database backup aliniyor..."

docker exec -t postgres_db pg_dump -U website website_db | Out-File -Encoding ascii db/dumps/latest.sql

Write-Host "Backup tamamlandi: db/dumps/latest.sql"