from django.urls import path
from . import views

app_name = 'documents'

urlpatterns = [
    path('<int:group_id>/', views.document_list_view, name='document_list'),
]