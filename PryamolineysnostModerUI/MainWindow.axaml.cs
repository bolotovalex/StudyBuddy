using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PryamolineysnostModerUI
{
    public partial class MainWindow : Window
    {
        public int Count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ExitButton_Click()
        {

        }

        private void ExitButton_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Counter_Click(object? sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            btn.Content = $"Counter: {++Count}";
            
        }
    }
}