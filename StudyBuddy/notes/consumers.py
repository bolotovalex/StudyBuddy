import json

from channels.db import database_sync_to_async
from channels.generic.websocket import AsyncWebsocketConsumer
from .models import Note


class NoteConsumer(AsyncWebsocketConsumer):
    async def connect(self):
        self.note_id = self.scope['url_route']['kwargs']['note_id']
        self.note_group_name = f'note_{self.note_id}'

        # Присоединяемся к группе
        await self.channel_layer.group_add(
            self.note_group_name,
            self.channel_name
        )
        await self.accept()

    async def disconnect(self, close_code):
        # Удаляем из группы
        await self.channel_layer.group_discard(
            self.note_group_name,
            self.channel_name
        )

    async def receive(self, text_data):
        data = json.loads(text_data)
        content = data['content']

        # Обновляем содержимое конспекта
        note = await self.get_note()
        note.content = content
        await self.save_note(note)

        # Отправляем изменения другим пользователям
        await self.channel_layer.group_send(
            self.note_group_name,
            {
                'type': 'note_update',
                'content': content
            }
        )

    async def note_update(self, event):
        content = event['content']
        await self.send(text_data=json.dumps({
            'content': content
        }))

    @staticmethod
    async def get_note():
        return await database_sync_to_async(Note.objects.get)(id=self.note_id)

    @staticmethod
    async def save_note(note):
        await database_sync_to_async(note.save)()