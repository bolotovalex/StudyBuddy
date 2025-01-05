# groups/forms.py

from django import forms
from .models import StudyGroup

class StudyGroupForm(forms.ModelForm):
    #Добавляем поля для группы(комныты)
    class Meta:
        model = StudyGroup
        fields = ['name', 'description']