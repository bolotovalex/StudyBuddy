# groups/forms.py

from django import forms
from .models import StudyGroup

class StudyGroupForm(forms.ModelForm):
    #Добавляем поля для группы(комныты)
    class Meta:
        model = StudyGroup
        fields = ['name', 'description']

class EditGroupForm(forms.ModelForm):
    class Meta:
        model = StudyGroup
        fields = ['description']
        widgets = {
            'description': forms.Textarea(attrs={
                'rows': 5,
                'cols': 40,
                'placeholder': 'Введите новое описание группы'
            }),
        }
        labels = {
            'description': 'Описание группы',
        }