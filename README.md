# Full Stack Web Project

## Gereksinimler:

* Docker

---

## Kurulum:

git clone https://github.com/mustafabarissolak/Youtube-Full-Stack-Web-Project.git

cd Youtube-Full-Stack-Web-Project

---

## Projeyi başlatma:

#### Windows (PowerShell)

Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

.\scripts\restore.ps1

#### Mac / Linux

chmod +x scripts/*.sh

./scripts/restore.sh

---

## Bu ne yapar?

* Docker containerlarını başlatır
* En güncel veritabanı snapshot’unu yükler
* Projeyi çalışır hale getirir

---

## Güncel veriyi almak:


git pull

#### Windows

.\scripts\restore.ps1

#### Mac/Linux

./scripts/restore.sh

---

## Veritabanını sıfırlamak:

docker compose down -v

### Windows

.\scripts\restore.ps1

### Mac/Linux

./scripts/restore.sh

---
