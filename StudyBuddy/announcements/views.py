from django.contrib.auth.decorators import login_required, user_passes_test
from django.shortcuts import render, redirect
from .models import Announcement

def is_admin(user):
    return user.role == 'admin'

@login_required
@user_passes_test(is_admin)
def create_announcement(request):
    if request.method == 'POST':
        title = request.POST.get('title')
        content = request.POST.get('content')
        Announcement.objects.create(title=title, content=content, created_by=request.user)
        return redirect('announcements:list')
    return render(request, 'announcements/create.html')

@login_required
def list_announcements(request):
    announcements = Announcement.objects.order_by('-created_at')
    return render(request, 'announcements/list.html', {'announcements': announcements})
