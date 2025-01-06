from django.urls import path
from .views import add_document_view

app_name = 'documents'

urlpatterns = [
    path('add/<int:group_id>/', add_document_view, name='add_document'),
]