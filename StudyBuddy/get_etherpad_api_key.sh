#!/bin/bash
set -e

# Получаем ключ из etherpad-контейнера
ETHERPAD_API_KEY=$(docker exec etherpad cat /opt/etherpad-lite/APIKEY.txt)

export ETHERPAD_API_KEY

# Запускаем основной процесс (замени на свою команду запуска)
exec "$@"
