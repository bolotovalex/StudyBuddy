from django.shortcuts import render, get_object_or_404, redirect
from django.contrib.auth.decorators import login_required
from .models import Question, Answer

@login_required
def question_list(request):
    """
    Отображает список вопросов. Если задан параметр поиска, фильтрует вопросы по тексту.
    """
    query = request.GET.get('q', '')
    questions = Question.objects.filter(question_text__icontains=query) if query else Question.objects.all()
    return render(request, 'questions/question_list.html', {'questions': questions, 'query': query})

@login_required
def create_question(request):
    """
    Создаёт новый вопрос.
    """
    if request.method == 'POST':
        question_text = request.POST.get('question_text')
        Question.objects.create(question_text=question_text, created_by=request.user)
        return redirect('questions:question_list')
    return render(request, 'questions/create_question.html')

@login_required
def question_detail(request, pk):
    """
    Отображает детали вопроса и список ответов на него. Позволяет добавить новый ответ.
    """
    question = get_object_or_404(Question, pk=pk)
    answers = question.answers.all()
    if request.method == 'POST':
        answer_text = request.POST.get('answer_text')
        Answer.objects.create(question=question, answer_text=answer_text, created_by=request.user)
        return redirect('questions:question_detail', pk=pk)
    return render(request, 'questions/question_detail.html', {
        'question': question,
        'answers': answers,
    })

@login_required
def delete_question(request, pk):
    """
    Удаляет вопрос, если текущий пользователь является его создателем.
    """
    question = get_object_or_404(Question, pk=pk, created_by=request.user)
    question.delete()
    return redirect('questions:question_list')