from django import forms
from .models import VideoMeeting

class MeetingForm(forms.ModelForm):
    class Meta:
        model = VideoMeeting
        fields = ['title', 'scheduled_at']  # Поле `link` больше не требуется