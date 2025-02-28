from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import VideoMeeting, StudyGroup
from .forms import MeetingForm

@login_required
def add_meeting_view(request, group_id):
    """
    Добавляет новое собрание для указанной группы.
    """
    group = get_object_or_404(StudyGroup, pk=group_id)
    if request.method == 'POST':
        form = MeetingForm(request.POST)
        if form.is_valid():
            meeting = form.save(commit=False)
            meeting.group = group
            meeting.created_by = request.user
            meeting.save()
            # Перенаправляем на страницу группы после добавления собрания
            return redirect('groups:group_detail', pk=group.id)
    else:
        form = MeetingForm()
    # Отображаем форму добавления собрания
    return render(request, 'add_meeting.html', {'form': form, 'group': group})