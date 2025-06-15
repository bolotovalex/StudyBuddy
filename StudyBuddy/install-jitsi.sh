#!/bin/bash
set -e

JITSI_DIR="docker-jitsi-meet"
PUBLIC_URL="https://meet.study.ilexx-tech.ru"
rm -rf "$JITSI_DIR"
mkdir -p "$JITSI_DIR"

echo "📥 Скачиваем docker-jitsi-meet..."
ZIP_URL=$(curl -s https://api.github.com/repos/jitsi/docker-jitsi-meet/releases/latest \
  | grep 'zipball_url' | cut -d\" -f4)

curl -L "$ZIP_URL" -o jitsi.zip

echo "📦 Распаковываем..."
unzip jitsi.zip -d tmp-jitsi-unzip
rm jitsi.zip

mv tmp-jitsi-unzip/* "$JITSI_DIR"
rmdir tmp-jitsi-unzip

cd "$JITSI_DIR"

cp env.example .env
chmod +x gen-passwords.sh
./gen-passwords.sh

sed -i "s|^#PUBLIC_URL=.*|PUBLIC_URL=$PUBLIC_URL|" .env
sed -i "s|^ENABLE_LETSENCRYPT=.*|ENABLE_LETSENCRYPT=0|" .env
sed -i "s|^#DISABLE_HTTPS=.*|DISABLE_HTTPS=1|" .env
