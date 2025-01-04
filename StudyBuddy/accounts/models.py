from django.db import models
from django.contrib.auth.models import AbstractUser

class User(AbstractUser):
    ROLE_CHOICES = (
        ('admin', 'Администратор'),
        ('user', 'Пользователь'),
    )
    role = models.CharField(
        max_length=10,
        choices=ROLE_CHOICES,
        default='user',
        verbose_name='Роль'
    )

    def __str__(self):
        return self.username


class Profile(models.Model):
    user = models.OneToOneField(User, on_delete=models.CASCADE, related_name='profile')

    # Вместо одного поля full_name делим на три поля:
    last_name = models.CharField(max_length=100, verbose_name='Фамилия', blank=False)
    first_name = models.CharField(max_length=100, verbose_name='Имя', blank=False)
    patronymic = models.CharField(max_length=100, verbose_name='Отчество', blank=False)

    birth_date = models.DateField(
        null=True, blank=False,
        verbose_name='Дата рождения'
    )
    institution = models.CharField(
        max_length=255,
        verbose_name='Учебное заведение',
        blank=True
    )
    faculty = models.CharField(
        max_length=255,
        verbose_name='Факультет',
        blank=True
    )
    study_group = models.CharField(
        max_length=255,
        verbose_name='Группа',
        blank=True
    )

    def __str__(self):
        return f"Профиль пользователя {self.user.username}"