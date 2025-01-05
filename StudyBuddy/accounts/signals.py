from django.db.models.signals import post_save
from django.dispatch import receiver
from .models import User, Profile

'''
Нужно для вызова редактирования профиля при создании учетки.
'''

@receiver(post_save, sender=User)
def create_user_profile(sender, instance, created, **kwargs):
    if created:
        Profile.objects.create(user=instance)