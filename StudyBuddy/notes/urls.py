from django.urls import path
from . import views

app_name = 'notes'

urlpatterns = [
    path('<int:group_id>/', views.note_list_view, name='note_list'),
]