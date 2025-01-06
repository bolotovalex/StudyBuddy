from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Note, StudyGroup


@login_required
def note_list_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)
    notes = group.notes.all()
    return render(request, 'notes/note_list.html', {'group': group, 'notes': notes})

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
            Note.objects.create(
                group=group,
                title=title,
                content=content,
                created_by=request.user
            )
            return redirect('groups:group_detail', pk=group.id)
    
    return render(request, 'notes/add_note.html', {'group': group})