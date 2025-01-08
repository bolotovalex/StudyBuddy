from django.db import models
from django.contrib.auth.models import User
from django.conf import settings

class Question(models.Model):
    """
    Модель для вопроса.
    """
    # Текст вопроса
    question_text = models.TextField()
    # Пользователь, создавший вопрос
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name='questions')
    # Дата и время создания вопроса
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        # Возвращает первые 50 символов текста вопроса
        return self.question_text[:50] + ('...' if len(self.question_text) > 50 else '')

class Answer(models.Model):
    """
    Модель для ответа на вопрос.
    """
    # Связь с вопросом
    question = models.ForeignKey(Question, on_delete=models.CASCADE, related_name='answers')
    # Текст ответа
    answer_text = models.TextField()
    # Пользователь, создавший ответ
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name='answers')
    # Дата и время создания ответа
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        # Возвращает первые 50 символов текста ответа
        return self.answer_text[:50] + ('...' if len(self.answer_text) > 50 else '')