Write-Host "🚀 Containerlar başlatılıyor..."

docker compose up -d

Write-Host "⏳ DB hazır olması bekleniyor..."

$ready = $false

while (-not $ready) {
    docker exec postgres_db pg_isready -U website > $null 2>&1
    if ($LASTEXITCODE -eq 0) {
        $ready = $true
    } else {
        Start-Sleep -Seconds 2
    }
}

Write-Host "📥 Backup yükleniyor..."

Get-Content db/dumps/latest.sql | docker exec -i postgres_db psql -U website -d website_db

Write-Host "✅ Database hazır!"