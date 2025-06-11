from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Note, StudyGroup
import uuid, requests
from django.conf import settings


@login_required
def add_note_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)

    if request.method == 'POST':
        title = request.POST.get('title')
        if title:
            pad_id = f"group{group.id}_{uuid.uuid4().hex[:8]}"
            create_pad(pad_id)
            note = Note.objects.create(
                group=group,
                title=title,
                etherpad_id=pad_id,
                created_by=request.user
            )
            return redirect(note.get_etherpad_url())

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

def create_pad(pad_id):
    response = requests.get(
        f"{settings.ETHERPAD_API_URL}/createPad",
        params={"apikey": settings.ETHERPAD_API_KEY, "padID": pad_id}
    )
    response.raise_for_status()
