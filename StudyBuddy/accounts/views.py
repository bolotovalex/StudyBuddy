from django.contrib.auth import login, logout
from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from django.contrib import messages
from .forms import CustomUserCreationForm, UserLoginForm, ProfileForm
from groups.models import StudyGroup
from .models import User, Profile
from .forms import UserRegistrationForm


def home_view(request):
    """
    Главная страница — форма авторизации и кнопка регистрации.
    """
    # Если пользователь уже авторизован, просто перенаправляем куда-то, например, в профиль
    if request.user.is_authenticated:
        return redirect('groups:group_list')

    if request.method == 'POST':
        form = UserLoginForm(request, data=request.POST)
        if form.is_valid():
            user = form.get_user()
            login(request, user)
            # profile = user.profile
        return redirect('groups:group_list')
        #     return render(request, 'accounts/profile.html', {'profile': profile, 'is_own_profile': True})
        #     # return redirect('accounts:profile')
    else:
        form = UserLoginForm(request)

    return render(request, 'accounts/home.html', {'form': form})

def register_view(request):
    if request.user.is_authenticated:
        return redirect('accounts:profile')

    if request.method == 'POST':
        form = UserRegistrationForm(request.POST)
        if form.is_valid():
            user = form.save()  # Создаём пользователя
            # Создаём профиль
            Profile.objects.create(
                user=user,
                first_name=form.cleaned_data['first_name'],
                last_name=form.cleaned_data['last_name'],
                patronymic=form.cleaned_data['patronymic'],
                birth_date=form.cleaned_data['birth_date'],
                institution=form.cleaned_data['institution'],
                faculty=form.cleaned_data['faculty'],
                study_group=form.cleaned_data['study_group'],
            )
            login(request, user)  # Сразу авторизуем пользователя
            return redirect('groups:group_list')  # Перенаправляем на список групп
    else:
        form = UserRegistrationForm()

    return render(request, 'accounts/register.html', {'form': form})


# def register_view(request):
#     """
#     Регистрация нового пользователя.
#     """
#     if request.user.is_authenticated:
#         return redirect('accounts:profile')
#
#     if request.method == 'POST':
#         form = CustomUserCreationForm(request.POST)
#         if form.is_valid():
#             user = form.save()  # Создаём пользователя
#             login(request, user)  # Сразу логиним
#             Profile.objects.create(
#                 user=user,
#                 first_name=form.cleaned_data['first_name'],
#                 last_name=form.cleaned_data['last_name'],
#                 patronymic=form.cleaned_data['patronymic'],
#                 birth_date=form.cleaned_data['birth_date'],
#                 institution=form.cleaned_data['institution'],
#                 faculty = form.cleaned_data['faculty'],
#                 study_group = form.cleaned_data['study_group'],
#             )
#             messages.success(request, 'Регистрация прошла успешно! Заполните профиль.')
#
#             return redirect('groups:group_list')  # Редирект на страницу заполнения профиля
#     else:
#         form = CustomUserCreationForm()
#
#     return render(request, 'accounts/register.html', {'form': form})


@login_required
def edit_profile_view(request):
    """
    Редактирование профиля пользователя.
    """
    profile = request.user.profile
    is_own_profile = True  # Только для своего профиля
    if request.method == 'POST':
        form = ProfileForm(request.POST, instance=profile)
        if form.is_valid():
            form.save()
            messages.success(request, 'Профиль обновлён.')
            return redirect('accounts:profile')
    else:
        form = ProfileForm(instance=profile)

    return render(request, 'accounts/edit_profile.html', {'form': form, 'is_own_profile': is_own_profile})



@login_required
def profile_view(request):
    """
    Страница профиля текущего пользователя.
    """
    profile = request.user.profile
    return render(request, 'accounts/profile.html', {'profile': profile, 'is_own_profile': True})



def logout_view(request):
    logout(request)
    return redirect('accounts:home')


@login_required
def delete_account_view(request):
    """
    Удаляет профиль и учётную запись пользователя.
    """
    if request.method == 'POST':
        # Удаляем текущего пользователя
        user = request.user
        user.delete()
        # При удалении пользователя через user.delete()
        # его профиль (OneToOneField с on_delete=models.CASCADE) удалится автоматически.

        messages.success(request, 'Ваш профиль и учетная запись были удалены.')
        return redirect('accounts:home')  # Или на любую другую страницу

    # Если метод GET – показываем страницу подтверждения
    return render(request, 'accounts/delete_account_confirm.html')

@login_required
def request_access_view(request, pk):
    """
    Запрашивает доступ в группу.
    """
    group = get_object_or_404(StudyGroup, pk=pk)

    '''Проверяем, не состоит ли пользователь уже в группе'''
    if request.user in group.members.all():
        messages.error(request, "Вы уже являетесь участником этой группы.")
        return redirect('groups:group_detail', pk=pk)

    '''Проверяем, не отправлен ли уже запрос на доступ'''
    if request.user in group.access_requests.all():
        messages.error(request, "Вы уже отправили запрос на доступ.")
        return redirect('groups:group_detail', pk=pk)

    # Добавляем пользователя в запросы
    group.access_requests.add(request.user)
    messages.success(request, "Ваш запрос на доступ отправлен.")
    return redirect('groups:group_list')

@login_required
def user_profile_view(request, user_id):
    """
    Отображает профиль другого пользователя.
    """
    user = get_object_or_404(User, id=user_id)
    profile = user.profile
    is_own_profile = (request.user == user)
    return render(request, 'accounts/profile.html', {'profile': profile, 'is_own_profile': is_own_profile})
