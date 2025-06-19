from django.db import models
from django.conf import settings
from ckeditor.fields import RichTextField

class Announcement(models.Model):
    title = models.CharField(max_length=200, verbose_name="Заголовок")
    content = RichTextField(verbose_name="Текст объявления")
    image = models.ImageField(upload_to='announcements/', blank=True, null=True, verbose_name="Изображение")
    created_at = models.DateTimeField(auto_now_add=True)
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)

    def __str__(self):
        return self.title