from django.db import models
from django.conf import settings
from groups.models import StudyGroup
import os

def group_directory_path(instance, filename):
    # Путь к файлу: group_<id>/<filename>
    return f'group_documents/group_{instance.group.id}/{filename}'

class Document(models.Model):
    # Связь с учебной группой
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='documents')
    # Пользователь, загрузивший документ
    uploaded_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
    # Файл документа
    file = models.FileField(upload_to=group_directory_path)
    # Описание документа
    description = models.TextField(blank=True)
    # Дата и время загрузки
    uploaded_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        # Возвращает имя файла
        return self.file.name

    def get_file_type(self):
        # Возвращает тип файла на основе расширения
        if self.file.name.endswith('.pdf'):
            return 'pdf'
        elif self.file.name.endswith(('.doc', '.docx')):
            return 'word'
        elif self.file.name.endswith(('.xls', '.xlsx')):
            return 'excel'
        else:
            return 'other'

    def get_file_name(self):
        # Возвращает имя файла без пути
        return os.path.basename(self.file.name)
