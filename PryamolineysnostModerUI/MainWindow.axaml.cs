using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace PryamolineysnostModerUI
{
    public partial class MainWindow : Window
    {
        public enum Panels
        {
            Home,
            Data,
            Graphic,
            PdfPanel
        }

        private Panels _selectedPanel = Panels.Home;
        
        private int _count;
        
        public MainWindow()
        {
            InitializeComponent();
            ChangePanel(Panels.Home);
        }


        private void CheckButton(Button pButton)
        {
            pButton.Background = new SolidColorBrush(Colors.LightSkyBlue);
        }

        private void UncheckButton(Button pButton)
        {
            pButton.Background = new SolidColorBrush(Color.FromRgb(247,247,247));
        }

        private Button GetAccentButton(Panels p)
        {
            switch (p)
            {
                case Panels.Home:
                    return HomeButton;
                case Panels.Data:
                    return DataButton;
                case Panels.Graphic:
                    return GraphicButton;
                case Panels.PdfPanel:
                    return PdfButton;
            }

            return HomeButton;
        }
        private void ChangePanel(Panels panel)
        {
            var prevButton = GetAccentButton(_selectedPanel);
            prevButton.Background = new SolidColorBrush(Color.FromRgb(247,247,247));
            _selectedPanel = panel;
            var nextButton = GetAccentButton(_selectedPanel);
            nextButton.Background = new SolidColorBrush(Colors.LightSkyBlue);
        }
       

        private void ExitButton_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Counter_Click(object? sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            btn.Content = $"Counter: {++_count}";
            
        }
    }
}