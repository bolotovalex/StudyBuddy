from django.urls import path
from . import views

app_name = 'accounts'

urlpatterns = [
    path('', views.home_view, name='home'),  # Главная страница
    path('register/', views.register_view, name='register'),
    path('profile/', views.profile_view, name='profile'),
    path('profile/edit/', views.edit_profile_view, name='edit_profile'),
    path('logout/', views.logout_view, name='logout'),
    path('profile/delete/', views.delete_account_view, name='delete_account'),

]