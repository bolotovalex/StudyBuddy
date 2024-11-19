using PryamolineynostNew.Views;

namespace PryamolineynostNew.ViewModels
{
    public class HomePageViewModel : PageViewModelBase
    {
        /// <summary>
        /// The Title of this page
        /// </summary>
        public string Title => "Главная страница";

        /// <summary>
        /// The content of this page
        /// </summary>
        public string Message => "Сообщение";

        // This is our first page, so we can navigate to the next page in any case
        //public override bool CanNavigateNext
        //{
        //    get => true;
        //    protected set => throw new NotSupportedException();
        //}

        //// You cannot go back from this page
        //public override bool CanNavigatePrevious
        //{
        //    get => false;
        //    protected set => throw new NotSupportedException();
        //}
    }
}
