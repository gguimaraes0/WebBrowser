using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        public MainWindow()
        {
            InitializeComponent();
            webView = new WebView(this);
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
                configurationView = new ConfigurationView();

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
    }
}
