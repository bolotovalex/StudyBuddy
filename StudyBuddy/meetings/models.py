from django.conf import settings
from groups.models import StudyGroup
from django.db import models
from django.contrib.auth.models import User
from groups.models import StudyGroup
import uuid

from django.conf import settings
import uuid

class VideoMeeting(models.Model):
    group = models.ForeignKey(StudyGroup, on_delete=models.CASCADE, related_name='meetings')
    title = models.CharField(max_length=255)
    link = models.URLField(blank=True, null=True)
    scheduled_at = models.DateTimeField()
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)

    def save(self, *args, **kwargs):
        if not self.link:
            unique_meeting_name = f"{uuid.uuid4().hex[:8]}-{uuid.uuid4().hex[:4]}"
            self.link = f"{settings.JITSI_BASE_URL}/{unique_meeting_name}"
        super().save(*args, **kwargs)

    def __str__(self):
        return self.title