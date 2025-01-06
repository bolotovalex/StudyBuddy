from django.urls import path
from . import views

app_name = 'notes'

urlpatterns = [
    path('<int:group_id>/', views.add_note_view, name='add_note'),
]