from django.shortcuts import render, get_object_or_404
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from chat.models import Message
from groups.models import StudyGroup

# Create your views here.
@login_required
def chat_view(request, group_id):
    group = get_object_or_404(StudyGroup, id=group_id)
    messages = group.messages.all()
    return render(request, 'chat/chat.html', {'group': group, 'messages': messages})

@login_required
def send_message(request):
    if request.method == 'POST':
        group_id = request.POST.get('group_id')
        content = request.POST.get('content')
        group = get_object_or_404(StudyGroup, id=group_id)
        message = Message.objects.create(
            group=group,
            user=request.user,
            content=content
        )
        return JsonResponse({'status': 'success', 'message': 'Сообщение отправлено!'})
    return JsonResponse({'status': 'error', 'message': 'Неверный метод.'})