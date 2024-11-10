using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace PryamolineysnostModerUI
{
    public partial class MainWindow : Window
    {
        public enum PressedButton
        {
            Home,
            Data,
            Graphic,
            Pdf,
            Load,
            Save,
            Settings,
            Exit
        }

        private PressedButton SelectedPressedButton = PressedButton.Home;
        private PressedButton PrevPressedButton = PressedButton.Exit;
        
        private int Count = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            ChangePanel(PressedButton.Home);
            DataPanel.IsVisible = false;
            GraphicPanel.IsVisible = false;
            PdfPanel.IsVisible = false;
            SavePanel.IsVisible = false;
            LoadPanel.IsVisible = false;
            SettingsPanel.IsVisible = false;
            ExitPanel.IsVisible = false;
        }


        private void CheckButton(Button pButton)
        {
            if (SelectedPressedButton == PressedButton.Exit)
            {
                pButton.Background = new SolidColorBrush(Colors.LightCoral);    
            }
            else
            {
                pButton.Background = new SolidColorBrush(Colors.LightSkyBlue);
            }
            
        }

        private void UncheckButton(Button pButton)
        {
            pButton.Background = new SolidColorBrush(Color.FromRgb(247,247,247));
        }

        private Button GetAccentButton(PressedButton p)
        {
            switch (p)
            {
                case PressedButton.Home:
                    return HomeButton;
                case PressedButton.Data:
                    return DataButton;
                case PressedButton.Graphic:
                    return GraphicButton;
                case PressedButton.Pdf:
                    return PdfButton;
                case PressedButton.Save:
                    return SaveButton;
                case PressedButton.Load:
                    return LoadButton;
                case PressedButton.Settings:
                    return SettingsButton;
                case PressedButton.Exit:
                    return ExitButton;
            }

            return HomeButton;
        }

        private Panel GetPanel(PressedButton p)
        {
            switch (p)
            {
                case PressedButton.Home:
                    return MainPanel;
                case PressedButton.Data:
                    return DataPanel;
                case PressedButton.Graphic:
                    return GraphicPanel;  
                case PressedButton.Pdf:
                    return PdfPanel;
                case PressedButton.Load:
                    return LoadPanel;
                case PressedButton.Save:
                    return SavePanel;
                case PressedButton.Settings:
                    return SettingsPanel;
                case PressedButton.Exit:
                    return ExitPanel;
            }

            return MainPanel;
        }
        
        private void ChangePanel(PressedButton pressedButton)
        {
            PrevPressedButton = SelectedPressedButton;
            
            var prevButton = GetAccentButton(SelectedPressedButton);
            UncheckButton(prevButton);
            var prevPanel = GetPanel(SelectedPressedButton);
            prevPanel.IsVisible = false;
            
            SelectedPressedButton = pressedButton;
            
            var nextButton = GetAccentButton(SelectedPressedButton);
            CheckButton(nextButton);
            var nextPanel = GetPanel(SelectedPressedButton);
            nextPanel.IsVisible = true;
        }
       

        private void ConfirmExitButton_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void UnconfirmExitButton_OnClick(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PrevPressedButton);
        }

        private void HomeButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Home);
        }

        private void DataButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Data);
        }

        private void GraphicButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Graphic);
        }
        
        private void PdfButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Pdf);
        }
        
        private void LoadButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Load);
        }
        
        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Save);
        }
        
        private void SettingsButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Settings);
        }
        
        private void ExitButton_Click(object? sender, RoutedEventArgs e)
        {
            ChangePanel(PressedButton.Exit);
        }
        

        private void Counter_Click(object? sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            btn.Content = $"Counter: {++Count}";
            
        }
    }
}