from django.urls import path
from . import views

app_name = 'meetings'

urlpatterns = [
    path('<int:group_id>/', views.add_meeting_view, name='add_meeting'),
    path('<int:pk>/meeting/delete', views.delete_meeting_view, name='delete_meeting'),
    path('<int:pk>/meeting/delete/confirm/', views.meeting_confirm_delete, name='meeting_confirm_delete'),

]