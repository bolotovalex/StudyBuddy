from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Document

@login_required
def document_list_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)
    documents = group.documents.all()
    return render(request, 'documents/document_list.html', {'group': group, 'documents': documents})