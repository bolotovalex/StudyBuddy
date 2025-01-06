from django.db import models
from django.conf import settings
from groups.models import StudyGroup

class VideoMeeting(models.Model):
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='meetings')
    title = models.CharField(max_length=255, verbose_name="Название встречи")
    link = models.URLField(verbose_name="Ссылка на встречу")
    #TODO Нужно добавить выбор даты
    scheduled_at = models.DateTimeField(verbose_name="Дата и время встречи")
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)

    def __str__(self):
        return self.title