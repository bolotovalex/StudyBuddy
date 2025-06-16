#!/bin/bash
set -e

# === 0. Задать имя домена и папку с сертификатами ===
DOMAIN="meet.study.ilexx-tech.ru"
CERTS_DIR="./docker/nginx/certs/live/$DOMAIN"
rm -rf jitsi-docker-jitsi-meet-*
# === 1. Скачать и распаковать последнюю версию docker-jitsi-meet ===
echo "==> Downloading latest docker-jitsi-meet release…"
ZIP_URL=$(curl -s https://api.github.com/repos/jitsi/docker-jitsi-meet/releases/latest | grep 'zip' | cut -d\" -f4)
ZIP_FILE=${ZIP_URL##*/}
wget -nc "$ZIP_URL"
if [ -z "$(ls -d jitsi-docker-jitsi-meet-*/ 2>/dev/null)" ]; then
    unzip -n "$ZIP_FILE"
fi



# === 2. Найти реальную папку Jitsi и перейти в неё ===
JITSI_DIR=$(ls -d jitsi-docker-jitsi-meet-*/ 2>/dev/null | head -n1)
if [ -z "$JITSI_DIR" ]; then
    echo "Jitsi directory not found!"
    exit 1
fi
cd "$JITSI_DIR" || { echo "Can't cd into extracted folder!"; exit 1; }

# === 3. Копировать .env.example → .env (если не существует) ===
if [ ! -f .env ]; then
    echo "==> Creating .env from env.example"
    cp env.example .env
else
    echo "==> .env already exists, skipping"
fi

# === 4. Подставить PUBLIC_URL и отключить LetsEncrypt в .env ===
echo "==> Setting PUBLIC_URL and disabling Let's Encrypt in .env"
sed -i "s|^PUBLIC_URL=.*|PUBLIC_URL=https://$DOMAIN|" .env
sed -i "s|^ENABLE_LETSENCRYPT=.*|ENABLE_LETSENCRYPT=0|" .env
sed -i "s|^DISABLE_HTTPS=.*|DISABLE_HTTPS=0|" .env

# === 5. Генерировать пароли (если не сгенерировано) ===
./gen-passwords.sh

# === 6. Создать конфиг директории ===
CFG="$HOME/.jitsi-meet-cfg"
echo "==> Creating config directories at $CFG"
mkdir -p "$CFG/web" "$CFG/transcripts" "$CFG/prosody/config" "$CFG/prosody/prosody-plugins-custom" "$CFG/jicofo" "$CFG/jvb" "$CFG/jigasi" "$CFG/jibri"

# === 7. Копировать SSL-сертификаты ===
CRT_SRC="$CERTS_DIR/fullchain1.pem"
KEY_SRC="$CERTS_DIR/privkey1.pem"
CRT_DST="$CFG/web/crt.pem"
KEY_DST="$CFG/web/key.pem"

if [ -f "$CRT_SRC" ] && [ -f "$KEY_SRC" ]; then
    echo "==> Copying certificates from $CERTS_DIR"
    cp "$CRT_SRC" "$CRT_DST"
    cp "$KEY_SRC" "$KEY_DST"
    echo "==> Certificates copied to $CFG/web/"
else
    echo "==> Certificate files not found in $CERTS_DIR"
    echo "Place your certificates as fullchain.pem and privkey.pem in $CERTS_DIR and run this script again, or copy manually to $CFG/web/crt.pem and $CFG/web/key.pem"
fi

# === 8. Готово! Подсказка для запуска ===
echo "==> Setup done!"
echo "To start Jitsi, run: docker compose -f docker-compose.yml up -d"
