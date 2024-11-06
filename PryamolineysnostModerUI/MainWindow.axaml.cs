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

        public Panels SelectedPanel = Panels.Home;
        
        public int Count = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            ChangePanel(Panels.Home);
            DataPanel.IsVisible = false;
            GraphicPanel.IsVisible = false;
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

        private Panel GetPanel(Panels p)
        {
            switch (p)
            {
                case Panels.Home:
                    return MainPanel;
                case Panels.Data:
                    return DataPanel;
                case Panels.Graphic:
                    return GraphicPanel;    
            }

            return MainPanel;
        }
        
        private void ChangePanel(Panels panel)
        {
            var prevButton = GetAccentButton(SelectedPanel);
            UncheckButton(prevButton);
            var prevPanel = GetPanel(SelectedPanel);
            prevPanel.IsVisible = false;
            SelectedPanel = panel;
            var nextButton = GetAccentButton(SelectedPanel);
            CheckButton(nextButton);
            var nextPanel = GetPanel(SelectedPanel);
            nextPanel.IsVisible = true;
        }
       

        private void ExitButton_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HomeButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(Panels.Home);
        }

        private void DataButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(Panels.Data);
        }

        private void GraphicButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(Panels.Graphic);
        }

        private void Counter_Click(object? sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            btn.Content = $"Counter: {++Count}";
            
        }
    }
}