from django.db import models
from django.conf import settings
from django.shortcuts import render, get_object_or_404
from accounts.models import User
from django.contrib.auth.decorators import login_required

class StudyGroup(models.Model):
    """
    Модель для учебной группы.
    """
    name = models.CharField(max_length=255, verbose_name='Название группы')
    description = models.TextField(blank=True, verbose_name='Описание группы')

    # Владелец группы
    owner = models.ForeignKey(settings.AUTH_USER_MODEL,
                on_delete=models.CASCADE,
                related_name='owned_groups',
                null=True,
                blank=True
    )

    # Участники группы
    members = models.ManyToManyField(
        settings.AUTH_USER_MODEL,
        blank=True,
        related_name='study_groups'
    )

    # Запросы на доступ
    access_requests = models.ManyToManyField(
        settings.AUTH_USER_MODEL,
        blank=True,
        related_name='group_access_requests'

    )

    def delete(self, *args, **kwargs):
        # Удаление связанных файлов перед удалением группы
        for document in self.documents.all():
            if document.file:
                document.file.delete()  # Удаляет файл из файловой системы
        super().delete(*args, **kwargs)

    def __str__(self):
        # Возвращает название группы
        return self.name
