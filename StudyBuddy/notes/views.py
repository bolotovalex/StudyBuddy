from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Note, StudyGroup
import uuid, requests
from django.conf import settings
from urllib.parse import quote
import re


def make_safe_pad_id(group):
    base = f"group{group.id}"
    uid = uuid.uuid4().hex[:8]
    pad_id = f"{base}_{uid}"
    # Удаляем всё лишнее для Etherpad (безопасный pad_id)
    pad_id = re.sub(r'[^a-zA-Z0-9_\-]', '', pad_id)
    return pad_id

@login_required
def add_note_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)
    if request.method == 'POST':
        title = request.POST.get('title')
        description = request.POST.get('description')
        if title:
            pad_id = make_safe_pad_id(group)
            create_pad(pad_id)
            note = Note.objects.create(
                group=group,
                title=title,
                description=description,
                etherpad_id=pad_id,
                created_by=request.user
            )
            user_name = request.user.get_full_name() or request.user.username
            return redirect(f"{settings.ETHERPAD_BASE_URL}/p/{pad_id}/?userName={quote(user_name)}")
    return render(request, 'notes/add_note.html', {'group': group})



@login_required
def edit_note_view(request, note_id):
    note = get_object_or_404(Note, id=note_id)
    user_name = request.user.get_full_name() or request.user.username
    from urllib.parse import quote
    return redirect(f"{settings.ETHERPAD_BASE_URL}/p/{note.etherpad_id}/?userName={quote(user_name)}")


def create_pad(pad_id):
    response = requests.get(
        f"{settings.ETHERPAD_API_URL}/createPad",
        params={"apikey": settings.ETHERPAD_API_KEY, "padID": pad_id}
    )
    response.raise_for_status()

@login_required
def note_etherpad_redirect(request, pad_id):
    user = request.user
    user_name = quote(user.get_full_name() or user.username)
    url = f"{settings.ETHERPAD_BASE_URL}/p/{pad_id}/?userName={user_name}"
    return redirect(url)