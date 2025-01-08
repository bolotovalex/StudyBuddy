from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Note, StudyGroup

@login_required
def add_note_view(request, group_id):
    """
    Создаём новый конспект.
    """
    group = get_object_or_404(StudyGroup, id=group_id)

    if request.method == 'POST':
        title = request.POST.get('title')
        content = request.POST.get('content')
        if title and content:
            # Создаём новый конспект
            Note.objects.create(
                group=group,
                title=title,
                content=content,
                created_by=request.user
            )
            # Перенаправляем на страницу группы после добавления конспекта
            return redirect('groups:group_detail', pk=group.id)
    
    # Отображаем форму добавления конспекта
    return render(request, 'notes/add_note.html', {'group': group})

@login_required
def edit_note_view(request, note_id):
    """
    Редактируем существующий конспект.
    """
    note = get_object_or_404(Note, id=note_id)
    if request.method == 'POST':
        note.title = request.POST.get('title')
        note.content = request.POST.get('content')
        note.save()
        # Перенаправляем на страницу группы после редактирования конспекта
        return redirect('groups:group_detail', pk=note.group.id)
    
    # Отображаем форму редактирования конспекта
    return render(request, 'notes/edit_note.html', {'note': note})