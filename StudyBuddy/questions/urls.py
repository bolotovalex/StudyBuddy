from django.urls import path
from . import views

app_name = 'questions'

urlpatterns = [
    path('', views.question_list, name='question_list'),
    path('create/', views.create_question, name='create_question'),
    path('<int:pk>/', views.question_detail, name='question_detail'),
    path('<int:pk>/delete/', views.delete_question, name='delete_question'),
]