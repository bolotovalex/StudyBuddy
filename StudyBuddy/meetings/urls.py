from django.urls import path
from . import views

app_name = 'meetings'

urlpatterns = [
    path('<int:group_id>/', views.add_meeting_view, name='add_meeting'),
]