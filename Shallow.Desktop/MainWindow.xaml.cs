using CefSharp;
using CefSharp.Wpf;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Interface;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigurationView configurationView;
        WebView webView = null;
        public ICustomBrowser ICustomBrowser { get; set; }

        public ResponsavelModel ResponsavelModel { get; set; }
        public CriancaModel CriancaModel { get; set; }


        public MainWindow(ResponsavelModel responsavel = null, CriancaModel crianca = null)
        {
            CriancaModel = crianca;
            ResponsavelModel = responsavel;
            InitializeComponent();
            webView = new WebView(this, responsavel, crianca);
            ICustomBrowser = webView;
            SwitchRegistrationsView(webView);
        }

        private void SwitchRegistrationsView(UserControl view)
        {
            if (!GridView.Children.Contains(view))
            {
                view.Visibility = Visibility.Visible;
                GridView.Children.Add(view);
            }
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            if (configurationView == null)
                configurationView = new ConfigurationView(ResponsavelModel, CriancaModel);

            if (configurationView.Visibility == Visibility.Collapsed)
            {
                SwitchRegistrationsView(webView);
            }
            else
            {
                SwitchRegistrationsView(configurationView);
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (GridView.Children.Count > 1)
            {
                GridView.Children.Remove(configurationView);
            }
            else
                ICustomBrowser.HomePage();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            ICustomBrowser.ForwardPage(false);

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ICustomBrowser.PreviousPage(false);

        }
    }
}
