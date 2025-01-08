from groups.models import StudyGroup
from django.db import models
from django.contrib.auth.models import User
from django.conf import settings
import uuid

class VideoMeeting(models.Model):
    """
    Модель для видеоконференции.
    """
    # Связь с учебной группой
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='meetings')
    # Название встречи
    title = models.CharField(max_length=255)
    # Ссылка на видеоконференцию
    link = models.URLField(blank=True, null=True)
    # Запланированное время встречи
    scheduled_at = models.DateTimeField()
    # Пользователь, создавший встречу
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)

    def save(self, *args, **kwargs):
        """
        Действие при нажатии на кнопку сохранить при создании встречи.
        Формируется произвольная ссылка для сервера JITSI, если ссылка не указана.
        """
        if not self.link:
            unique_meeting_name = f"{uuid.uuid4().hex[:8]}-{uuid.uuid4().hex[:4]}"
            self.link = f"{settings.JITSI_BASE_URL}/{unique_meeting_name}"
        super().save(*args, **kwargs)

    def __str__(self):
        # Возвращает название встречи
        return self.title