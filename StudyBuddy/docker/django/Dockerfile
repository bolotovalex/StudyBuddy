# Установка Python
FROM python:3.13-slim

# Установка зависимостей
RUN apt-get update && apt-get install -y build-essential libpq-dev

# Установка рабочей директории
WORKDIR /app

# Установка зависимостей из requirements.txt
COPY docker/django/requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Копирование проекта
COPY . .

RUN python manage.py collectstatic --noinput


# Expose порта для Daphne
EXPOSE 8000