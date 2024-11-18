using System;
using System.Net.Mime;
using System.Xml;
using Avalonia;
using PryamolineynostNew.Views;
using Tmds.DBus.Protocol;

namespace PryamolineynostNew.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        private string _asd;
        public string Greeting => "Welcome to Avalonia!";
        public void TextChange()
        {
        }
        
        public string NameAsd
        {
            get => _asd;
            set => SetProperty(ref _asd, value);
        }

        public void ExitButton_Click()
        {
            Environment.Exit(0);
        }
#pragma warning restore CA1822 // Mark members as static
    }
}
