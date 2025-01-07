# groups/views.py

from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from django.contrib import messages
from .models import StudyGroup
from chat.models import Message
from .forms import StudyGroupForm, EditGroupForm
from django.contrib.auth import get_user_model


'''Отображаем список групп, после авторизации'''
@login_required
def group_list_view(request):
    query = request.GET.get('q', '')  # Получаем значение из параметра 'q'
    if query:
        groups = StudyGroup.objects.filter(name__icontains=query)  # Фильтруем группы по имени
    else:
        groups = StudyGroup.objects.all()  # Если запроса нет, выводим все группы
    return render(request, 'groups/group_list.html', {'groups': groups, 'query': query})

'''Создаем группу'''
@login_required
def create_group_view(request):
    if request.method == 'POST':
        form = StudyGroupForm(request.POST)
        if form.is_valid():
            # Сохраняем, но пока без коммита, чтобы добавить owner
            group = form.save(commit=False)
            group.owner = request.user  # Владельцем становится создатель
            group.save()

            # Добавим создателя в участники (опционально)
            group.members.add(request.user)

            messages.success(request, 'Новая группа создана!')
            return redirect('groups:group_list')
    else:
        form = StudyGroupForm()

    return render(request, 'groups/create_group.html', {'form': form})


def delete_group_view(request, pk):
    """
    Удаляет группу, если текущий пользователь - владелец.
    Если в группе остаются пользователи, они становятся владельцами.
    Если пользователей не остаётся, группа удаляется.
    """
    group = get_object_or_404(StudyGroup, pk=pk)

    # Проверяем, что текущий пользователь — владелец
    if group.owner != request.user:
        messages.error(request, 'У вас нет прав на удаление этой группы.')
        return redirect('groups:group_list')

    if request.method == 'POST':
        # Получаем всех пользователей группы, кроме текущего владельца
        remaining_members = group.members.exclude(pk=request.user.pk)

        if remaining_members.exists():
            # Если есть оставшиеся пользователи, выбираем нового владельца
            new_owner = remaining_members.first()
            group.owner = new_owner  # Назначаем нового владельца
            group.save()

            # Удаляем текущего владельца из участников
            group.members.remove(request.user)
            messages.success(request, f'Вы покинули группу. Новым владельцем стал {new_owner.username}.')
        else:
            # Если пользователей больше нет, удаляем группу
            group.delete()
            messages.success(request, 'Группа удалена, так как в ней не осталось участников.')

        return redirect('groups:group_list')

    # Если метод GET — показываем страницу подтверждения
    return render(request, 'groups/delete_group_confirm.html', {'group': group})

@login_required
def group_detail_view(request, pk):
    """
    Страница конкретной группы, с отображением списка участников.
    """
    group = get_object_or_404(StudyGroup, pk=pk)
    documents = group.documents.all()
    notes = group.notes.all()
    meetings = group.meetings.all()
    messages = group.messages.all()  # Получаем сообщения для группы

    # join_requests = GroupJoinRequest.objects.filter(group=group)

    # Проверяем, состоит ли пользователь в группе
    if request.user not in group.members.all():
        messages.error(request, "Вы не являетесь участником этой группы.")
        return redirect('groups:group_list')

    # Получаем всех участников группы
    members = group.members.all()

    return render(request, 'groups/group_detail.html', {
        'group': group,
        'documents': documents,
        'notes': notes,
        'meetings': meetings,
        'members': members,
        'messages': messages,
    })


@login_required
def leave_group_view(request, pk):
    """
    Пользователь покидает группу.
    """
    group = get_object_or_404(StudyGroup, pk=pk)

    # Проверяем, что пользователь состоит в группе
    if request.user in group.members.all():
        group.members.remove(request.user)  # Удаляем пользователя из участников
        messages.success(request, f'Вы покинули группу "{group.name}".')
    else:
        messages.error(request, 'Вы не состоите в этой группе.')

    if group.members.count() == 0:
        group.delete()

    return redirect('groups:group_list')

@login_required
def request_access_view(request, pk):
    """
    Запрашивает доступ в группу.
    """
    group = get_object_or_404(StudyGroup, pk=pk)
    if request.user in group.members.all():
        messages.error(request, "Вы уже являетесь участником этой группы.")
        return redirect('groups:group_detail', pk=pk)

    if request.user in group.access_requests.all():
        messages.error(request, "Вы уже отправили запрос на доступ.")
        return redirect('groups:group_detail', pk=pk)

    group.access_requests.add(request.user)
    messages.success(request, "Ваш запрос на доступ отправлен.")
    return redirect('groups:group_list')


@login_required
def accept_request_view(request, pk, user_id):
    """
    Принимает запрос пользователя на доступ в группу.
    """
    group = get_object_or_404(StudyGroup, pk=pk)
    if group.owner != request.user:
        messages.error(request, "У вас нет прав на управление этой группой.")
        return redirect('groups:group_detail', pk=pk)

    User = get_user_model()  # Получаем модель пользователя
    user = get_object_or_404(User, pk=user_id)  # Ищем пользователя по ID

    if user in group.access_requests.all():
        group.access_requests.remove(user)
        group.members.add(user)
        messages.success(request, f"Пользователь {user.username} добавлен в группу.")
    else:
        messages.error(request, "Запрос не найден.")

    return redirect('groups:group_detail', pk=pk)


@login_required
def decline_request_view(request, pk, user_id):
    """
    Отклоняет запрос пользователя на доступ в группу.
    """
    group = get_object_or_404(StudyGroup, pk=pk)
    if group.owner != request.user:
        messages.error(request, "У вас нет прав на управление этой группой.")
        return redirect('groups:group_detail', pk=pk)

    User = get_user_model()  # Получаем модель пользователя
    user = get_object_or_404(User, pk=user_id)  # Ищем пользователя по ID

    if user in group.access_requests.all():
        group.access_requests.remove(user)
        messages.success(request, f"Запрос от пользователя {user.username} отклонён.")
    else:
        messages.error(request, "Запрос не найден.")

    return redirect('groups:group_detail', pk=pk)

@login_required
def edit_group_view(request, pk):
    """
    Позволяет владельцу группы редактировать её описание.
    """
    group = get_object_or_404(StudyGroup, pk=pk)

    # Проверяем, что текущий пользователь является владельцем группы
    if group.owner != request.user:
        messages.error(request, "Вы не имеете прав на редактирование этой группы.")
        return redirect('groups:group_detail', pk=pk)

    if request.method == 'POST':
        form = EditGroupForm(request.POST, instance=group)
        if form.is_valid():
            form.save()
            messages.success(request, "Описание группы обновлено.")
            return redirect('groups:group_detail', pk=pk)
    else:
        form = EditGroupForm(instance=group)

    return render(request, 'groups/edit_group.html', {'form': form, 'group': group})

@login_required
def user_profile_view(request, user_id):
    """
    Отображает профиль другого пользователя.
    """
    user = get_object_or_404(User, id=user_id)
    profile = user.profile
    return render(request, 'accounts/profile.html', {'profile': profile})