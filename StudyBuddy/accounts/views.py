from django.shortcuts import render, redirect
from django.contrib.auth import login, logout
from django.contrib.auth.decorators import login_required
from django.contrib.auth.forms import AuthenticationForm
from django.contrib import messages
from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from django.contrib import messages
from .forms import CustomUserCreationForm, UserLoginForm, ProfileForm
from groups.models import StudyGroup
from .models import User


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
            return redirect('groups:group_list')
        #     user = form.get_user()
        #     login(request, user)
        #     profile = user.profile
        #     return render(request, 'accounts/profile.html', {'profile': profile, 'is_own_profile': True})
        #     # return redirect('accounts:profile')
    else:
        form = UserLoginForm(request)

    return render(request, 'accounts/home.html', {'form': form})


def register_view(request):
    """
    Регистрация нового пользователя.
    """
    if request.user.is_authenticated:
        return redirect('accounts:profile')

    if request.method == 'POST':
        form = CustomUserCreationForm(request.POST)
        if form.is_valid():
            user = form.save()  # Создаём пользователя
            login(request, user)  # Сразу логиним
            messages.success(request, 'Регистрация прошла успешно! Заполните профиль.')
            return redirect('accounts:edit_profile')  # Редирект на страницу заполнения профиля
    else:
        form = CustomUserCreationForm()

    return render(request, 'accounts/register.html', {'form': form})


@login_required
def edit_profile_view(request):
    """
    Заполнение или редактирование профиля (ФИО, дата рождения).
    """
    profile = request.user.profile  # благодаря OneToOneField
    if request.method == 'POST':
        form = ProfileForm(request.POST, instance=profile)
        if form.is_valid():
            form.save()
            messages.success(request, 'Профиль обновлён.')
            return redirect('groups:group_list')
    else:
        form = ProfileForm(instance=profile)

    return render(request, 'accounts/edit_profile.html', {'form': form})


@login_required
def profile_view(request):
    """
    Страница профиля. Отображаем ФИО, дату рождения, список групп (пока заглушка).
    """
    profile = request.user.profile
    return render(request, 'accounts/profile.html', {'profile': profile})


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