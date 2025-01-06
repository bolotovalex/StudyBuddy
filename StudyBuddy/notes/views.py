from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Note

@login_required
def note_list_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)
    notes = group.notes.all()
    return render(request, 'notes/note_list.html', {'group': group, 'notes': notes})