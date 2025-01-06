from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Document, StudyGroup
from django.contrib import messages


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

@login_required
def delete_document_view(request, document_id):
        """
        Удаляет документ после подтверждения.
        """
        document = get_object_or_404(Document, id=document_id)

        if request.method == 'POST':
            document.file.delete()  # Удаляем сам файл из файловой системы
            document.delete()  # Удаляем запись из базы данных
            messages.success(request, "Документ успешно удалён.")
            return redirect('groups:group_detail', pk=document.group.id)

        return render(request, 'documents/confirm_delete.html', {'document': document})