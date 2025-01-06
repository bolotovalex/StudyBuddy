import json
from channels.generic.websocket import AsyncWebsocketConsumer

class NoteConsumer(AsyncWebsocketConsumer):
    async def connect(self):
        self.note_id = self.scope['url_route']['kwargs']['note_id']
        self.note_group_name = f'note_{self.note_id}'

        # Присоединяемся к группе WebSocket
        await self.channel_layer.group_add(
            self.note_group_name,
            self.channel_name
        )
        await self.accept()

    async def disconnect(self, close_code):
        # Покидаем группу WebSocket
        await self.channel_layer.group_discard(
            self.note_group_name,
            self.channel_name
        )

    async def receive(self, text_data):
        # Получаем данные от клиента
        data = json.loads(text_data)
        content = data['content']

        # Передаём изменения всем участникам группы
        await self.channel_layer.group_send(
            self.note_group_name,
            {
                'type': 'note_update',
                'content': content
            }
        )

    async def note_update(self, event):
        # Отправляем данные клиенту
        content = event['content']
        await self.send(text_data=json.dumps({
            'content': content
        }))