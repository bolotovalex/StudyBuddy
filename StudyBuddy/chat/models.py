from django.db import models
from django.contrib.auth.models import User
from groups.models import StudyGroup
from accounts.models import User

class Message(models.Model):
    # Связь с учебной группой
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name="messages")
    # Связь с пользователем, отправившим сообщение
    user = models.ForeignKey(User, on_delete=models.CASCADE)
    # Содержимое сообщения
    content = models.TextField()
    # Время отправки сообщения
    timestamp = models.DateTimeField(auto_now_add=True)

    class Meta:
        # Сортировка сообщений по времени отправки
        ordering = ['timestamp']

    def __str__(self):
        # Строковое представление сообщения
        return f"{self.user.username}: {self.content[:20]}"