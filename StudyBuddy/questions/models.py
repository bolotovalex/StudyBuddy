from django.db import models
from django.contrib.auth.models import User
from django.conf import settings

class Question(models.Model):
    question_text = models.TextField()
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name='questions')
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return self.question_text[:50] + ('...' if len(self.question_text) > 50 else '')

class Answer(models.Model):
    question = models.ForeignKey(Question, on_delete=models.CASCADE, related_name='answers')
    answer_text = models.TextField()
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name='answers')
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return self.answer_text[:50] + ('...' if len(self.answer_text) > 50 else '')