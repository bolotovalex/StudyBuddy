from django import forms
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.core.exceptions import ValidationError

from . import models
from .models import User, Profile


class CustomUserCreationForm(UserCreationForm):
    class Meta:
        model = User
        fields = ('username', 'email', 'role')


class UserLoginForm(AuthenticationForm):
    #TODO Придумать как разграничить роли.
    pass


class ProfileForm(forms.ModelForm):
    class Meta:
        model = Profile
        fields = ['first_name', 'last_name', 'patronymic', 'birth_date', 'institution', 'faculty', 'study_group']
        widgets = {
            'birth_date': forms.DateInput(attrs={'type': 'date'}),  # HTML5-виджет для выбора даты
        }
    
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

# class UserRegistrationForm(forms.ModelForm):
#     password = forms.CharField(widget=forms.PasswordInput)
#     confirm_password = forms.CharField(widget=forms.PasswordInput)
#
#     class Meta:
#         model = User
#         fields = ['username', 'email', 'password', 'password_confirm', 'first_name', 'last_name', 'patronymic', 'birth_date', 'institution', 'faculty', 'study_group']
#
#     def clean_username(self):
#         username = self.cleaned_data.get('username')
#         if User.objects.filter(username=username).exists():
#             raise ValidationError("Пользователь с таким именем уже существует.")
#         return username
#
#     def clean_email(self):
#         email = self.cleaned_data.get('email')
#         if User.objects.filter(email=email).exists():
#             raise ValidationError("Пользователь с таким email уже существует.")
#         return email
#
#     def clean(self):
#         cleaned_data = super().clean()
#         password = cleaned_data.get('password')
#         confirm_password = cleaned_data.get('confirm_password')
#         if password and confirm_password and password != confirm_password:
#             raise ValidationError("Пароли не совпадают.")
#         return cleaned_data

class UserRegistrationForm(UserCreationForm):
    # Поля профиля
    first_name = forms.CharField(max_length=30, required=True, label="Имя")
    last_name = forms.CharField(max_length=30, required=True, label="Фамилия")
    patronymic = forms.CharField(max_length=30, required=False, label="Отчество")
    birth_date = forms.DateField(required=True, label="Дата рождения",
                                 widget=forms.DateInput(attrs={'type': 'date'}))
    institution = forms.CharField(max_length=255, required=False, label="Учебное заведение")
    faculty = forms.CharField(max_length=255, required=False, label="Факультет")
    study_group = forms.CharField(max_length=255, required=False, label="Группа")

    class Meta:
        model = User
        fields = ['username', 'email', 'password1', 'password2', 'first_name', 'last_name', 'patronymic',
                  'birth_date', 'institution', 'faculty', 'study_group']

    def clean_password_confirm(self):
        password = self.cleaned_data.get('password')
        password_confirm = self.cleaned_data.get('password_confirm')

        if password != password_confirm:
            raise forms.ValidationError("Пароли не совпадают")
        return password_confirm
