"""
ASGI config for StudyBuddy project.

It exposes the ASGI callable as a module-level variable named ``application``.

For more information on this file, see
https://docs.djangoproject.com/en/5.1/howto/deployment/asgi/
"""
#
# import os
#
# from django.core.asgi import get_asgi_application
#
# os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'StudyBuddy.settings')
#
# application = get_asgi_application()

import os
from django.core.asgi import get_asgi_application
from channels.routing import ProtocolTypeRouter, URLRouter
from channels.auth import AuthMiddlewareStack
from notes.routing import websocket_urlpatterns

os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'StudyBuddy.settings')

application = ProtocolTypeRouter({
    "http": get_asgi_application(),  # Для обработки HTTP-запросов
    "websocket": AuthMiddlewareStack(
        URLRouter(
            websocket_urlpatterns  # Подключение маршрутов WebSocket
        )
    ),
})