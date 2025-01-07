from django.db import models
from django.conf import settings
from groups.models import StudyGroup

def group_directory_path(instance, filename):
    # Путь к файлу: group_<id>/<filename>
    return f'group_documents/group_{instance.group.id}/{filename}'


class Document(models.Model):
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='documents')
    uploaded_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
    file = models.FileField(upload_to=group_directory_path)
    #     file = models.FileField(upload_to=f'group_documents/')
    description = models.TextField(blank=True)
    uploaded_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
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

