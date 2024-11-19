using ReactiveUI;

namespace PryamolineynostNew.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _currentPage = _pages[0];
        }
        
        private readonly PageViewModelBase[] _pages =
        {
            new HomePageViewModel(),
            new DataPageViewModel(),
            new GraphicPageViewModel(),
            new SettingsPageViewModel()
        };
        
        private PageViewModelBase _currentPage;
        public PageViewModelBase CurrentPage
        {
            get { return _currentPage; }
            private set { this.RaiseAndSetIfChanged(ref _currentPage, value); }
        }

        public void SetHomePage() => CurrentPage = _pages[0];
        public void SetDataPage() => CurrentPage = _pages[1];
        public void SetGraphicPage() => CurrentPage = _pages[2];
        public void SetSettingsPage() =>CurrentPage = _pages[3];
        
        
    }
}
