from django.urls import path
from .views import add_note_view, edit_note_view
from . import consumers

app_name = 'notes'

urlpatterns = [
    path('<int:group_id>/', add_note_view, name='add_note'),
    path('edit/<int:note_id>/', edit_note_view, name='edit_note'),
]

websocket_urlpatterns = [
    path('ws/notes/<int:note_id>/', consumers.NoteConsumer.as_asgi()),
]