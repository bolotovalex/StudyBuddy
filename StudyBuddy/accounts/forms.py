from django import forms
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from captcha.fields import CaptchaField
from .models import User, Profile




class UserLoginForm(AuthenticationForm):
    username = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))
    password = forms.CharField(widget=forms.PasswordInput(attrs={'class': 'form-control'}))
    captcha = CaptchaField()
    
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['captcha'].widget.attrs.update({
         'class': 'input input-bordered w-full'
    })


class ProfileForm(forms.ModelForm):
    class Meta:
        model = Profile
        fields = ['photo', 'first_name', 'last_name', 'patronymic', 'birth_date', 'institution', 'faculty', 'study_group']
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
    captcha = CaptchaField()

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['captcha'].widget.attrs.update({
         'class': 'input input-bordered w-full'
    })

    class Meta:
        model = User
        fields = ['username', 'email', 'password1', 'password2', 'first_name', 'last_name', 'patronymic',
                  'birth_date', 'institution', 'faculty', 'study_group', 'captcha']

    def clean_password_confirm(self):
        password = self.cleaned_data.get('password')
        password_confirm = self.cleaned_data.get('password_confirm')

        if password != password_confirm:
            raise forms.ValidationError("Пароли не совпадают")
        return password_confirm
