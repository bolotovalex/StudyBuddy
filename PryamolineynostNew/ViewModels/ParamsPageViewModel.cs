using System;
using ReactiveUI;
using System.Reactive;

namespace PryamolineynostNew.ViewModels
{
    public class ParamsPageViewModel : PageViewModelBase
    {
        private string _projectName;

        public void UpdateProjectName(string projectName)
        {
            _projectName = projectName;
        }
        public string? ProjectName
        {
            get => _projectName;
            set => this.RaiseAndSetIfChanged(ref _projectName, value); 
        }

        public ParamsPageViewModel()
        {
            // Реакция на изменения в свойстве Text
            this.WhenAnyValue(x => x._projectName)
                .Subscribe(text => 
                {
                    // Логика при изменении текста
                    System.Diagnostics.Debug.WriteLine($"Text changed to: {text}");
                });
        }
        
    }
    
    
}
