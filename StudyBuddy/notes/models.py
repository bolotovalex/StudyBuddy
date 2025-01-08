from django.contrib.auth.decorators import login_required
from django.db import models
from django.conf import settings
from django.shortcuts import get_object_or_404, render, redirect
from django.contrib import messages

from groups.models import StudyGroup

class Note(models.Model):
    """
    Модель для конспекта.
    """
    # Связь с учебной группой
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='notes')
    # Название конспекта
    title = models.CharField(max_length=255, verbose_name="Название конспекта")
    # Содержимое конспекта
    content = models.TextField(verbose_name="Содержимое конспекта")
    # Пользователь, создавший конспект
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name='created_notes')
    # Дата и время создания
    created_at = models.DateTimeField(auto_now_add=True)
    # Дата и время обновления
    updated_at = models.DateTimeField(auto_now=True)

    def __str__(self):
        # Возвращает название конспекта
        return self.title

@login_required
def add_note_view(request, group_id):
    """
    Создаёт новый конспект.
    """
    group = get_object_or_404(StudyGroup, id=group_id)
    if request.method == 'POST':
        title = request.POST.get('title')
        content = request.POST.get('content')
        if title and content:
            Note.objects.create(
                group=group,
                title=title,
                content=content,
                created_by=request.user
            )
            messages.success(request, "Конспект успешно создан.")
            return redirect('groups:group_detail', pk=group.id)
        else:
            messages.error(request, "Название и содержимое не могут быть пустыми.")
    return render(request, 'notes/add_note.html', {'group': group})
