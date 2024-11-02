using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PryamolineysnostModerUI
{
    public partial class MainWindow : Window
    {
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
    }
}