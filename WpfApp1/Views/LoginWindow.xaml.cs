using System;
using System.Windows;


namespace WpfApp1.Views
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void bttLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
