from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import VideoMeeting, StudyGroup

@login_required
def add_meeting_view(request, group_id):
    """
    Добавляет новую видеовстречу.
    """
    group = get_object_or_404(StudyGroup, id=group_id)

    if request.method == 'POST':
        title = request.POST.get('title')
        link = request.POST.get('link')
        scheduled_at = request.POST.get('scheduled_at')
        if title and link and scheduled_at:
            VideoMeeting.objects.create(
                group=group,
                title=title,
                link=link,
                scheduled_at=scheduled_at,
                created_by=request.user
            )
            return redirect('groups:group_detail', pk=group.id)
    
    return render(request, 'meetings/add_meeting.html', {'group': group})