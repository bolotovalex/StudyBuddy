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