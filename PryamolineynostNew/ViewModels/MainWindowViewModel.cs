using System;
using System.Net.Mime;
using System.Xml;
using Avalonia;
using Avalonia.Controls;
using PryamolineynostNew.Views;
using Tmds.DBus.Protocol;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PryamolineynostNew.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand HomeButton_Clicked { get; }
        public ICommand DataButton_Clicked { get; }
        public ICommand GraphicButton_Clicked { get; }
        public ICommand PdfButton_Clicked { get; }
        public ICommand LoadButton_Clicked { get; }
        public ICommand SaveButton_Clicked { get; }
        public ICommand SettingsButton_Clicked { get; }
        public ICommand ExitButton_Clicked { get; }

        private Panel _prevPanel { get; set; }
        private Panel _selectedPanel
        
        {
            get => _selectedPanel;
            set => _prevPanel = _selectedPanel;
        }
    
        
        public MainWindowViewModel()
        {
            HomeButton_Clicked = new RelayCommand(HomeButton_Click);
            DataButton_Clicked = new RelayCommand(DataButton_Click);
            GraphicButton_Clicked = new RelayCommand(GraphicButton_Click);
            PdfButton_Clicked = new RelayCommand(GraphicButton_Click);
            LoadButton_Clicked = new RelayCommand(LoadButton_Click);
            SaveButton_Clicked = new RelayCommand(SaveButton_Click);
            SettingsButton_Clicked = new RelayCommand(SettingsButton_Click);
            ExitButton_Clicked = new RelayCommand(ExitButton_Click);
        }
        
        private void HomeButton_Click()
        {
            Console.WriteLine("Home");
        }

        private void DataButton_Click()
        {
            Console.WriteLine("Data");
        }

        private void GraphicButton_Click()
        {
            Console.WriteLine("Graphic");
        }

        private void ExitButton_Click()
        {
            Console.WriteLine("Exit");
            // Environment.Exit(0);
        }

        private void PdfButton_Click()
        {
            Console.WriteLine("Pdf");
        }

        private void LoadButton_Click()
        {
            Console.WriteLine("Load");
        }

        private void SaveButton_Click()
        {
            Console.WriteLine("Save");
        }

        private void SettingsButton_Click()
        {
            Console.WriteLine("Settings");
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
