#!/bin/bash
set -e
DOMAINS=("study.ilexx-tech.ru" "meet.study.ilexx-tech.ru")
for DOMAIN in "${DOMAINS[@]}"; do
  mkdir -p "./docker/nginx/certs/live/$DOMAIN"
done

for DOMAIN in "${DOMAINS[@]}"; do
  docker run --rm \
    -v "${PWD}/docker/nginx/certs/live/$DOMAIN:/certs" \
    alpine:latest \
    sh -c "apk add --no-cache openssl >/dev/null && \
      openssl req -x509 -nodes -days 365 \
        -newkey rsa:2048 \
        -subj '/CN=$DOMAIN' \
        -addext 'subjectAltName=DNS:$DOMAIN' \
        -keyout /certs/privkey.pem \
        -out /certs/fullchain.pem"
done

for DOMAIN in "${DOMAINS[@]}"; do
  echo "→ ./docker/nginx/certs/live/$DOMAIN/{fullchain.pem,privkey.pem}"
done
