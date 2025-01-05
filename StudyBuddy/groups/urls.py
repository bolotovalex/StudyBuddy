from django.urls import path
from . import views

app_name = 'groups'

urlpatterns = [
    path('', views.group_list_view, name='group_list'),
    path('create/', views.create_group_view, name='create_group'),
]