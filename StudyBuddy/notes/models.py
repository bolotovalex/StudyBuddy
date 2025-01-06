from django.db import models
from django.conf import settings
from groups.models import StudyGroup

class Note(models.Model):
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='notes')
    title = models.CharField(max_length=255, verbose_name="Название конспекта")
    content = models.TextField(verbose_name="Содержимое конспекта")
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name='created_notes')
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.title