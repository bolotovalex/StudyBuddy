from django.urls import path
from . import views

app_name = 'meetings'

urlpatterns = [
    path('<int:group_id>/', views.meeting_list_view, name='meeting_list'),
]