from django.db import models
from django.conf import settings

class StudyGroup(models.Model):
    """
    Модель для учебной группы.
    """
    name = models.CharField(max_length=255, verbose_name='Название группы')
    description = models.TextField(blank=True, verbose_name='Описание группы')

    # Владелец группы
    owner = models.ForeignKey(
                settings.AUTH_USER_MODEL,
                on_delete=models.CASCADE,
                related_name='owned_groups',
                null=True,
                blank=True
    )

    # Участники группы
    members = models.ManyToManyField(
        settings.AUTH_USER_MODEL,
        blank=True,
        related_name='study_groups'
    )

    # Запросы на доступ
    access_requests = models.ManyToManyField(
        settings.AUTH_USER_MODEL,
        blank=True,
        related_name='group_access_requests'

    )

    def __str__(self):
        return self.name

# from django.db import models
# from django.conf import settings
#
# class StudyGroup(models.Model):
#     """
#     Модель для учебной группы (комнаты), где пользователи могут совместно работать.
#     """
#     name = models.CharField(max_length=255, verbose_name='Название группы')
#     description = models.TextField(blank=True, verbose_name='Описание группы')
#
#     # Владелец группы (ForeignKey на пользователя)
#     '''
#
#     Добавил владельца как null. При пустой базе были ошибки'''
#     owner = models.ForeignKey(
#         settings.AUTH_USER_MODEL,
#         on_delete=models.CASCADE,
#         related_name='owned_groups',
#         null=True,
#         blank=True
#     )
#     # owner = models.ForeignKey(
#     #     settings.AUTH_USER_MODEL,
#     #     on_delete=models.CASCADE,
#     #     related_name='owned_groups'
#     # )
#
#     # Участники группы (ManyToMany, в том числе и владелец может быть в списке)
#     members = models.ManyToManyField(
#         settings.AUTH_USER_MODEL,
#         blank=True,
#         related_name='study_groups'
#     )
#
#     def __str__(self):
#         return self.name
