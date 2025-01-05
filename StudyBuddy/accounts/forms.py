from django import forms
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm

from .models import User, Profile


class CustomUserCreationForm(UserCreationForm):
    class Meta:
        model = User
        fields = ('username', 'email', 'role')


class UserLoginForm(AuthenticationForm):
    #TODO Придумать как разграничить роли.
    pass


class ProfileForm(forms.ModelForm):
    birth_date = forms.DateField(
        required=True,
        widget=forms.DateInput(attrs={'type': 'date'}),
        label='Дата рождения'
    )
    '''Поля профиля'''
    class Meta:
        model = Profile
        fields = (
            'last_name',
            'first_name',
            'patronymic',
            'birth_date',
            'institution',
            'faculty',
            'study_group',
        )
