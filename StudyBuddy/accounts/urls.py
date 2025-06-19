from django.urls import path
from . import views

app_name = 'accounts'

urlpatterns = [
    # path('', views.auth_form_view, name='home'),  # Главная страница
    path('register/', views.register_view, name='register'), # Форма регистрации
    path('profile/', views.profile_view, name='profile'), # Профиль пользователя
    path('profile/edit/', views.edit_profile_view, name='edit_profile'), #Редактирование профиля
    path('logout/', views.logout_view, name='logout'), # Выход из учетной записи
    path('profile/delete/', views.delete_account_view, name='delete_account'), # Удаление учетной записи
    path('profile/<int:user_id>/', views.user_profile_view, name='user_profile'),  # Профиль другого пользователя
    path('my/', views.my_groups_view, name='my_groups'),
    path('login/', views.auth_form_view, name='login'),
]