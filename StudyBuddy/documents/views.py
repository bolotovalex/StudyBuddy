from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Document

@login_required
def document_list_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)
    documents = group.documents.all()
    return render(request, 'documents/document_list.html', {'group': group, 'documents': documents})

@login_required
def add_document_view(request, group_id):
    """
    Добавляет новый документ.
    """
    group = get_object_or_404(StudyGroup, id=group_id)

    if request.method == 'POST':
        file = request.FILES.get('file')
        description = request.POST.get('description')
        if file:
            Document.objects.create(
                group=group,
                uploaded_by=request.user,
                file=file,
                description=description
            )
            return redirect('groups:group_detail', pk=group.id)
    
    return render(request, 'documents/add_document.html', {'group': group})