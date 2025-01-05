from django.urls import path
from . import views

app_name = 'groups'

urlpatterns = [
    path('', views.group_list_view, name='group_list'),
    path('create/', views.create_group_view, name='create_group'),
    path('<int:pk>/', views.group_detail_view, name='group_detail'),
    path('<int:pk>/request-access/', views.request_access_view, name='request_access'),
    path('<int:pk>/accept/<int:user_id>/', views.accept_request_view, name='accept_request'),
    path('<int:pk>/decline/<int:user_id>/', views.decline_request_view, name='decline_request'),
    path('<int:pk>/leave/', views.leave_group_view, name='leave_group'),
]